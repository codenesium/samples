using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Event", Schema="dbo")]
        public partial class Event : AbstractEntity
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

                [Column("AutoId")]
                public long AutoId { get; private set; }

                [Column("Category")]
                public string Category { get; private set; }

                [Column("EnvironmentId")]
                public string EnvironmentId { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Message")]
                public string Message { get; private set; }

                [Column("Occurred")]
                public DateTimeOffset Occurred { get; private set; }

                [Column("ProjectId")]
                public string ProjectId { get; private set; }

                [Column("RelatedDocumentIds")]
                public string RelatedDocumentIds { get; private set; }

                [Column("TenantId")]
                public string TenantId { get; private set; }

                [Column("UserId")]
                public string UserId { get; private set; }

                [Column("Username")]
                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>cc88df3c39982f57769ff11e55f5cc70</Hash>
</Codenesium>*/