using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Artifact", Schema="dbo")]
        public partial class Artifact: AbstractEntity
        {
                public Artifact()
                {
                }

                public void SetProperties(
                        DateTimeOffset created,
                        string environmentId,
                        string filename,
                        string id,
                        string jSON,
                        string projectId,
                        string relatedDocumentIds,
                        string tenantId)
                {
                        this.Created = created;
                        this.EnvironmentId = environmentId;
                        this.Filename = filename;
                        this.Id = id;
                        this.JSON = jSON;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.TenantId = tenantId;
                }

                [Column("Created", TypeName="datetimeoffset")]
                public DateTimeOffset Created { get; private set; }

                [Column("EnvironmentId", TypeName="nvarchar(50)")]
                public string EnvironmentId { get; private set; }

                [Column("Filename", TypeName="nvarchar(200)")]
                public string Filename { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("ProjectId", TypeName="nvarchar(50)")]
                public string ProjectId { get; private set; }

                [Column("RelatedDocumentIds", TypeName="nvarchar(-1)")]
                public string RelatedDocumentIds { get; private set; }

                [Column("TenantId", TypeName="nvarchar(50)")]
                public string TenantId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a451bac86b08b98def957f8adfc6bac1</Hash>
</Codenesium>*/