// (C) Copyright, Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted, 
// provided that the above copyright notice appears in all copies and 
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting 
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC. 
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.

// Written by Cyrille Fauvel, Autodesk Developer Network (ADN)
// http://www.autodesk.com/joinadn
//
#pragma warning disable 1591
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Dynamic;
using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Autodesk.Forge.Model {

	public class DynamicDictionary : DynamicObject {//, IEnumerable<KeyValuePair<string, object>> {
		public Dictionary<string, object> Dictionary { get; internal set; }

		public DynamicDictionary () : base () {
			Dictionary =new Dictionary<string, object> () ;
		}

		#region Get/Set
		public override bool TryGetMember (GetMemberBinder binder, out object result) {
			// Converting the property name to lowercase so that property names become case-insensitive.
			string name =binder.Name/*.ToLower ()*/ ;
			// If the property name is found in a dictionary, set the result parameter to the property value and return true.
			// Otherwise, return false.
			return (Dictionary.TryGetValue (name, out result)) ;
		}

		// If you try to set a value of a property that is not defined in the class, this method is called.
		public override bool TrySetMember (SetMemberBinder binder, object value) {
			// Converting the property name to lowercase so that property names become case-insensitive.
			Dictionary [binder.Name/*.ToLower ()*/] =value ;
			// You can always add a value to a dictionary, so this method always returns true.
			return (true) ;
		}

        public override bool TryDeleteMember (DeleteMemberBinder binder) {
            if ( Dictionary.ContainsKey (binder.Name/*.ToLower ()*/) )
                Dictionary.Remove (binder.Name/*.ToLower ()*/) ;
            return (true) ;
        }

        public override bool TryGetIndex (GetIndexBinder binder, object[] indexes, out object result) {
			if ( IsInteger (indexes [0]) ) {
			    int index =(int)indexes [0] ;
			    // If the property name is found in a dictionary, set the result parameter to the property value and return true.
			    // Otherwise, return false.
			    return (Dictionary.TryGetValue (index.ToString (), out result)) ;
            } //else
            return (Dictionary.TryGetValue (indexes [0].ToString (), out result)) ;
		}

        public override bool TrySetIndex (SetIndexBinder binder, object[] indexes, object value) {
            if ( IsInteger (indexes [0]) ) {
                int index =(int)indexes [0] ;
                // If a corresponding property already exists, set the value.
                if ( Dictionary.ContainsKey (index.ToString ()) )
                    Dictionary [index.ToString ()] =value ;
                else
                    // If a corresponding property does not exist, create it.
                    Dictionary.Add (index.ToString (), value) ;
            } else {
                 if ( Dictionary.ContainsKey (indexes [0].ToString ()) )
                    Dictionary [indexes [0].ToString ()] =value ;
                else
                    // If a corresponding property does not exist, create it.
                    Dictionary.Add (indexes [0].ToString (), value) ;
            }
            return (true) ;
        }

        public override bool TryDeleteIndex (DeleteIndexBinder binder, object[] indexes) {
            if ( IsInteger (indexes [0]) ) {
                int index =(int)indexes [0] ;
                if ( Dictionary.ContainsKey (index.ToString ()) )
                    Dictionary.Remove (index.ToString ()) ;
            } else {
                if ( Dictionary.ContainsKey (indexes [0].ToString ()) )
                    Dictionary.Remove (indexes [0].ToString ()) ;
            }
            return (true) ;
        }

		#endregion

		#region Enumerations
		public int Count {
			get { return (Dictionary.Count) ; }
		}

		public override IEnumerable<string> GetDynamicMemberNames () {
            return (from p in Dictionary select p.Key) ;
        }

		public virtual IEnumerable<KeyValuePair<string, object>> Items () {
			return (Dictionary) ;
		}

		//IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator () {
		//	return (Dictionary.GetEnumerator ()) ;
		//}

		//IEnumerator IEnumerable.GetEnumerator () {
		//	return (Dictionary.GetEnumerator ()) ;
		//}

		private static bool IsInteger (object value) {
            return (   value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    //|| value is float
                    //|| value is double
                    //|| value is decimal
            ) ;
        }

		#endregion

		#region ToString/ToJson
		public override string ToString () {
			return (ToString (Newtonsoft.Json.Formatting.None)) ;
		}

		public string ToString (Newtonsoft.Json.Formatting formatting =Newtonsoft.Json.Formatting.Indented) {
			JObject obj =ToJson () ;
			return (obj.ToString (formatting)) ;
		}

		internal void _ArrayDetection (ref JContainer obj) {
			bool bArray =true ;
			foreach ( JProperty prop in (obj as JObject).Properties () ) {
				int val =0 ;
				if ( Int32.TryParse (prop.Name, out val) != true ) {
					bArray =false ;
					break ;
				}
			}
			if ( bArray == true ) {
				JArray jarr =new JArray () ;
				foreach ( JProperty item in obj )
					jarr.Add (item.Value) ;
				obj =jarr ;
			}
			int nb =obj.Count ;
			for ( int i =0 ; i < nb ; i++ ) {
				JObject sub =null ;
				JProperty prop =obj.ElementAtOrDefault (i) as JProperty ;
				if ( prop != null ) {
					if ( prop.Value.GetType () == typeof (JObject) )
						sub =prop.Value.ToObject<JObject> () ;
				} else {
					sub =obj.ElementAtOrDefault (i) as JObject ;
				}
				if ( sub != null ) {
					JContainer container =sub as JContainer ;
					_ArrayDetection (ref container) ;
					if ( prop != null )
						prop.Value.Replace (container) ;
					else
						sub.Replace (container) ;
				}
			}
		}

		public JObject ToJson () {
			//JArray obj =(JArray)JToken.FromObject (this) ;
			//return (new JObject ()) ;
			JObject obj =(JObject)JToken.FromObject (this) ;
			JContainer container =obj as JContainer ;
			_ArrayDetection (ref container) ;
			return (obj) ;
		}

		#endregion
	}

	public class DynamicDictionaryItems : IEnumerable<KeyValuePair<string, object>> {
		private DynamicDictionary _dictionary ;

		private DynamicDictionaryItems () {
		}

		public DynamicDictionaryItems (DynamicDictionary dict) {
			_dictionary =dict ;
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator () {
			return (_dictionary.Dictionary.GetEnumerator ()) ;
		}

		IEnumerator IEnumerable.GetEnumerator () {
			return (_dictionary.Dictionary.GetEnumerator ()) ;
		}

	}

	public class DynamicJsonResponse : DynamicDictionary {

		#region Constructors
		public DynamicJsonResponse () : base () {
        }

		public DynamicJsonResponse (XDocument doc, string key ="Response") : base () {
			ProcessElement (doc.Element (key), this) ;
		}

		public DynamicJsonResponse (XElement elt) : base () {
			ProcessElement (elt, this) ;
		}

		public DynamicJsonResponse (JObject obj) : base () {
			ProcessObject (obj, this) ;
		}

		public DynamicJsonResponse (JArray obj) : base () {
			ProcessArray (obj, this) ;
		}

		#endregion

    public T ToObject<T>(){
      return (T)this.ToJson().ToObject(typeof(T));
    }

		#region Reading object utilities
		internal static void ProcessElement (XElement obj, DynamicDictionary dict) {
			var elList =from el in obj.Elements () select el ;
			foreach ( XElement elt in elList ) {
				if ( elt.HasElements == false ) {
					dict.Dictionary [elt.Name.LocalName] =(string)elt ;
				} else {
					// Careful, might be an array
					bool isArray =(elt.Elements ().Count () != elt.Elements().Select (el => el.Name).Distinct ().Count ()) ;
					DynamicDictionary subDict =new DynamicDictionary () ;
					if ( isArray )
						ProcessElementArray (elt, subDict) ;
					else
						ProcessElement (elt, subDict) ;
					dict.Dictionary [elt.Name.LocalName] =subDict ;
				}
			}
		}

		internal static void ProcessElementArray (XElement obj, DynamicDictionary dict) {
			var elList = from el in obj.Elements () select el ;
			int i =0 ;
			foreach ( XElement elt in elList ) {
				if ( elt.HasElements == false ) {
					dict.Dictionary [i.ToString ()] =(string)elt ;
				} else {
					// Careful, might be an array
					bool isArray =(elt.Elements ().Count () != elt.Elements().Select (el => el.Name).Distinct ().Count ()) ;
					DynamicDictionary subDict =new DynamicDictionary () ;
					ProcessElement (elt, subDict) ;
					if ( isArray )
						ProcessElementArray (elt, subDict) ;
					else
						ProcessElement (elt, subDict) ;
					dict.Dictionary [i.ToString ()] = subDict ;
				}
				i++ ;
			}
		}

		internal static void ProcessObject (JObject obj, DynamicDictionary dict) {
			foreach ( KeyValuePair<string, JToken> pair in obj ) {
				if ( pair.Value.GetType () == typeof (JValue) ) {
					dict.Dictionary [pair.Key] =((JValue)pair.Value).Value ;
				} else if ( pair.Value.GetType () == typeof (JObject) ) {
					DynamicDictionary subDict =new DynamicDictionary () ;
					ProcessObject ((JObject)(pair.Value), subDict) ;
					dict.Dictionary [pair.Key] =subDict ;
				} else if ( pair.Value.GetType () == typeof (JArray) ) {
					DynamicDictionary subDict =new DynamicDictionary () ;
					ProcessArray ((JArray)(pair.Value), subDict) ;
					dict.Dictionary [pair.Key] =subDict ;
				}
			}
		}

		internal static void ProcessArray (JArray obj, DynamicDictionary dict) {
			int i =0 ;
			foreach ( JToken item in obj ) {
				if ( item.GetType () == typeof (JValue) ) {
					dict.Dictionary [i.ToString ()] =((JValue)item).Value ;
				} else if ( item.GetType () == typeof (JObject) ) {
					DynamicDictionary subDict =new DynamicDictionary ();
					ProcessObject ((JObject)(item), subDict) ;
					dict.Dictionary [i.ToString ()] =subDict ;
				} else if ( item.GetType () == typeof (JArray) ) {
					DynamicDictionary subDict =new DynamicDictionary ();
					ProcessArray ((JArray)item, subDict) ;
					dict.Dictionary [i.ToString ()] =subDict ;
				}
				i++ ;
			}
		}

		#endregion

		//#region ToString/ToJson
		//public override string ToString () {
		//	return (ToString (Newtonsoft.Json.Formatting.None)) ;
		//}

		//public string ToString (Newtonsoft.Json.Formatting formatting =Newtonsoft.Json.Formatting.Indented) {
		//	JObject obj =ToJson () ;
		//	return (obj.ToString (formatting)) ;
		//}

		//internal void _ArrayDetection (ref JContainer obj) {
		//	bool bArray =true ;
		//	foreach ( JProperty prop in (obj as JObject).Properties () ) {
		//		int val =0 ;
		//		if ( Int32.TryParse (prop.Name, out val) != true ) {
		//			bArray =false ;
		//			break ;
		//		}
		//	}
		//	if ( bArray == true ) {
		//		JArray jarr =new JArray () ;
		//		foreach ( JProperty item in obj )
		//			jarr.Add (item.Value) ;
		//		obj =jarr ;
		//	}
		//	int nb =obj.Count ;
		//	for ( int i =0 ; i < nb ; i++ ) {
		//		JObject sub =null ;
		//		JProperty prop =obj.ElementAtOrDefault (i) as JProperty ;
		//		if ( prop != null ) {
		//			if ( prop.Value.GetType () == typeof (JObject) )
		//				sub =prop.Value.ToObject<JObject> () ;
		//		} else {
		//			sub =obj.ElementAtOrDefault (i) as JObject ;
		//		}
		//		if ( sub != null ) {
		//			JContainer container =sub as JContainer ;
		//			_ArrayDetection (ref container) ;
		//			if ( prop != null )
		//				prop.Value.Replace (container) ;
		//			else
		//				sub.Replace (container) ;
		//		}
		//	}
		//}

		//public JObject ToJson () {
		//	//JArray obj =(JArray)JToken.FromObject (this) ;
		//	//return (new JObject ()) ;
		//	JObject obj = (JObject)JToken.FromObject (this);
		//	JContainer container = obj as JContainer;
		//	_ArrayDetection (ref container);
		//	return (obj);
		//}

		//#endregion

	}

	partial class StringEnum {

		public static string ToEnumString<T> (T type) {
			var enumType =typeof (T) ;
			var name =Enum.GetName (enumType, type) ;
			var enumMemberAttribute =((EnumMemberAttribute [])enumType.GetField (name).GetCustomAttributes (typeof (EnumMemberAttribute), true)).Single () ;
			return (enumMemberAttribute.Value) ;
		}

		public static T ToEnum<T> (string str) {
			var enumType =typeof (T) ;
			foreach ( var name in Enum.GetNames (enumType) ) {
				var enumMemberAttribute =((EnumMemberAttribute [])enumType.GetField (name).GetCustomAttributes (typeof (EnumMemberAttribute), true)).Single () ;
				if ( enumMemberAttribute.Value == str )
					return ((T)Enum.Parse (enumType, name)) ;
			}
			//throw exception or whatever handling you want or
			return (default (T)) ;
		}

	}

}
#pragma warning restore 1591
