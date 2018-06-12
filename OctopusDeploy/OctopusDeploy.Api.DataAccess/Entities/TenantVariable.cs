using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("TenantVariable", Schema="dbo")]
        public partial class TenantVariable: AbstractEntity
        {
                public TenantVariable()
                {
                }

                public void SetProperties(
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

                [Column("EnvironmentId", TypeName="nvarchar(50)")]
                public string EnvironmentId { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("OwnerId", TypeName="nvarchar(50)")]
                public string OwnerId { get; private set; }

                [Column("RelatedDocumentId", TypeName="nvarchar(-1)")]
                public string RelatedDocumentId { get; private set; }

                [Column("TenantId", TypeName="nvarchar(50)")]
                public string TenantId { get; private set; }

                [Column("VariableTemplateId", TypeName="nvarchar(50)")]
                public string VariableTemplateId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7e09a3b97345788f62ad4bfd77b80c7f</Hash>
</Codenesium>*/