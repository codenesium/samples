using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Event", Schema="dbo")]
        public partial class Event:AbstractEntity
        {
                public Event()
                {
                }

                public void SetProperties(
                        long autoId,
                        string category,
                        string environmentId,
                        string id,
                        string jSON,
                        string message,
                        DateTimeOffset occurred,
                        string projectId,
                        string relatedDocumentIds,
                        string tenantId,
                        string userId,
                        string username)
                {
                        this.AutoId = autoId;
                        this.Category = category;
                        this.EnvironmentId = environmentId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Message = message;
                        this.Occurred = occurred;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.TenantId = tenantId;
                        this.UserId = userId;
                        this.Username = username;
                }

                [Column("AutoId", TypeName="bigint")]
                public long AutoId { get; private set; }

                [Column("Category", TypeName="nvarchar(50)")]
                public string Category { get; private set; }

                [Column("EnvironmentId", TypeName="nvarchar(50)")]
                public string EnvironmentId { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Message", TypeName="nvarchar(-1)")]
                public string Message { get; private set; }

                [Column("Occurred", TypeName="datetimeoffset")]
                public DateTimeOffset Occurred { get; private set; }

                [Column("ProjectId", TypeName="nvarchar(50)")]
                public string ProjectId { get; private set; }

                [Column("RelatedDocumentIds", TypeName="nvarchar(-1)")]
                public string RelatedDocumentIds { get; private set; }

                [Column("TenantId", TypeName="nvarchar(50)")]
                public string TenantId { get; private set; }

                [Column("UserId", TypeName="nvarchar(50)")]
                public string UserId { get; private set; }

                [Column("Username", TypeName="nvarchar(200)")]
                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1866810e494efcb2f9284b18c22356ef</Hash>
</Codenesium>*/