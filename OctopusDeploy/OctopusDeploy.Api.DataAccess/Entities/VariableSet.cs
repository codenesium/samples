using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("VariableSet", Schema="dbo")]
        public partial class VariableSet : AbstractEntity
        {
                public VariableSet()
                {
                }

                public virtual void SetProperties(
                        string id,
                        bool isFrozen,
                        string jSON,
                        string ownerId,
                        string relatedDocumentIds,
                        int version)
                {
                        this.Id = id;
                        this.IsFrozen = isFrozen;
                        this.JSON = jSON;
                        this.OwnerId = ownerId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Version = version;
                }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("IsFrozen")]
                public bool IsFrozen { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("OwnerId")]
                public string OwnerId { get; private set; }

                [Column("RelatedDocumentIds")]
                public string RelatedDocumentIds { get; private set; }

                [Column("Version")]
                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c7d6b409f65e84c83cfa17c57fa7036b</Hash>
</Codenesium>*/