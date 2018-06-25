using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("TenantVariable", Schema="dbo")]
        public partial class TenantVariable : AbstractEntity
        {
                public TenantVariable()
                {
                }

                public virtual void SetProperties(
                        string environmentId,
                        string id,
                        string jSON,
                        string ownerId,
                        string relatedDocumentId,
                        string tenantId,
                        string variableTemplateId)
                {
                        this.EnvironmentId = environmentId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.OwnerId = ownerId;
                        this.RelatedDocumentId = relatedDocumentId;
                        this.TenantId = tenantId;
                        this.VariableTemplateId = variableTemplateId;
                }

                [Column("EnvironmentId")]
                public string EnvironmentId { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("OwnerId")]
                public string OwnerId { get; private set; }

                [Column("RelatedDocumentId")]
                public string RelatedDocumentId { get; private set; }

                [Column("TenantId")]
                public string TenantId { get; private set; }

                [Column("VariableTemplateId")]
                public string VariableTemplateId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>96b110d7289472ecd2b5c10e9cfcec1a</Hash>
</Codenesium>*/