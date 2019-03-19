using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Autodesk.Forge.Model
{
    /// <summary>
    /// CreateItemsDataAttributes
    /// </summary>
    [DataContract]
    public partial class PatchItemDataAttributes : IEquatable<PatchItemDataAttributes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchItemDataAttributes" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PatchItemDataAttributes() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatchItemDataAttributes" /> class.
        /// </summary>
        /// <param name="hidden">True deletes item</param>
        /// <param name="name">New name for item</param>
        public PatchItemDataAttributes(bool hidden = false, string name = null)
        {
            this.Hidden = hidden;
            this.Name = name;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "hidden", EmitDefaultValue = false)]
        public bool Hidden { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PatchItemDataAttributes {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(obj as CreateItemDataAttributes);
        }


        /// <summary>
        /// Returns true if PatchItemDataAttributes instances are equal
        /// </summary>
        /// <param name="other">Instance of PatchItemDataAttributes to be compared</param>
        /// <returns>Boolean</returns>

        public bool Equals(PatchItemDataAttributes other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return
                (
                    this.Name == other.Name ||
                    !String.IsNullOrEmpty(this.Name) &&
                    this.Name.Equals(other.Name)
                ) &&
                (
                    this.Hidden == other.Hidden ||
                    this.Hidden.Equals(other.Hidden)
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
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                    hash = hash * 59 + this.Hidden.GetHashCode();
                return hash;
            }
        }


    }
}
