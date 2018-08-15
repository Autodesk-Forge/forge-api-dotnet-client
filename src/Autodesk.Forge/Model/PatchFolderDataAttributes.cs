using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Autodesk.Forge.Model
{
    /// <summary>
    /// CreateFolderDataAttributes
    /// </summary>
    [DataContract]
    public partial class PatchFolderDataAttributes : IEquatable<PatchFolderDataAttributes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchFolderDataAttributes" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PatchFolderDataAttributes() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatchFolderDataAttributes" /> class.
        /// </summary>
        /// <param name="hidden">True deletes folder</param>
        /// <param name="name">New name for folder</param>
        public PatchFolderDataAttributes(bool hidden = false, string name = null)
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
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PatchFolderDataAttributes {\n");
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
            return this.Equals(obj as CreateFolderDataAttributes);
        }


        /// <summary>
        /// Returns true if PatchFolderDataAttributes instances are equal
        /// </summary>
        /// <param name="other">Instance of PatchFolderDataAttributes to be compared</param>
        /// <returns>Boolean</returns>

        public bool Equals(PatchFolderDataAttributes other)
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
