using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Autodesk.Forge.Model
{
    /// <summary>
    /// CreateItemData
    /// </summary>
    [DataContract]
    public partial class PatchItemData : IEquatable<PatchItemData>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PatchItemData" /> class.
        /// </summary>
        /// <param name="Attributes">Attributes.</param>

        public PatchItemData(string itemId, PatchItemDataAttributes attributes = null)
        {
            this.Type = "items";
            this.Id = itemId;
            this.Attributes = attributes;
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }
        /// <summary>
        /// Gets or Sets Attributes
        /// </summary>
        [DataMember(Name = "attributes", EmitDefaultValue = false)]
        public PatchItemDataAttributes Attributes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PatchItemData {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Attributes: ").Append(Attributes).Append("\n");
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
            return this.Equals(obj as PatchItemData);
        }


        /// <summary>
        /// Returns true if PatchItemData instances are equal
        /// </summary>
        /// <param name="other">Instance of PatchItemData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PatchItemData other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return
                (
                    this.Attributes == other.Attributes ||
                    this.Attributes != null &&
                    this.Attributes.Equals(other.Attributes)
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
                if (this.Attributes != null)
                    hash = hash * 59 + this.Attributes.GetHashCode();
                return hash;
            }
        }
    }
}
