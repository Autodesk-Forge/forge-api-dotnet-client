using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Autodesk.Forge.Model
{
    [DataContract]
    public partial class PatchItem : IEquatable<PatchItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchItem" /> class.
        /// </summary>
        /// <param name="Jsonapi">Jsonapi.</param>
        /// <param name="Data">Data.</param>
        public PatchItem(JsonApiVersionJsonapi Jsonapi = null, PatchItemData Data = null)
        {
            this.Jsonapi = Jsonapi;
            this.Data = Data;
        }

        /// <summary>
        /// Gets or Sets Jsonapi
        /// </summary>
        [DataMember(Name = "jsonapi", EmitDefaultValue = false)]
        public JsonApiVersionJsonapi Jsonapi { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public PatchItemData Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PatchItem {\n");
            sb.Append("  Jsonapi: ").Append(Jsonapi).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }


        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as PatchItem);
        }


        /// <summary>
        /// Returns true if PatchItem instances are equal
        /// </summary>
        /// <param name="other">Instance of PatchItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PatchItem other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return
                (
                    this.Jsonapi == other.Jsonapi ||
                    this.Jsonapi != null &&
                    this.Jsonapi.Equals(other.Jsonapi)
                ) &&
                (
                    this.Data == other.Data ||
                    this.Data != null &&
                    this.Data.Equals(other.Data)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Jsonapi != null)
                    hash = hash * 59 + this.Jsonapi.GetHashCode();
                if (this.Data != null)
                    hash = hash * 59 + this.Data.GetHashCode();
                return hash;
            }
        }
    }
}
