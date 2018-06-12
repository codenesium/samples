using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Interruption", Schema="dbo")]
        public partial class Interruption: AbstractEntity
        {
                public Interruption()
                {
                }

                public void SetProperties(
                        DateTime created,
                        string environmentId,
                        string id,
                        string jSON,
                        string projectId,
                        string relatedDocumentIds,
                        string responsibleTeamIds,
                        string status,
                        string taskId,
                        string tenantId,
                        string title)
                {
                        this.Created = created;
                        this.EnvironmentId = environmentId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.ResponsibleTeamIds = responsibleTeamIds;
                        this.Status = status;
                        this.TaskId = taskId;
                        this.TenantId = tenantId;
                        this.Title = title;
                }

                [Column("Created", TypeName="datetimeoffset")]
                public DateTime Created { get; private set; }

                [Column("EnvironmentId", TypeName="nvarchar(50)")]
                public string EnvironmentId { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("ProjectId", TypeName="nvarchar(50)")]
                public string ProjectId { get; private set; }

                [Column("RelatedDocumentIds", TypeName="nvarchar(-1)")]
                public string RelatedDocumentIds { get; private set; }

                [Column("ResponsibleTeamIds", TypeName="nvarchar(-1)")]
                public string ResponsibleTeamIds { get; private set; }

                [Column("Status", TypeName="nvarchar(50)")]
                public string Status { get; private set; }

                [Column("TaskId", TypeName="nvarchar(50)")]
                public string TaskId { get; private set; }

                [Column("TenantId", TypeName="nvarchar(50)")]
                public string TenantId { get; private set; }

                [Column("Title", TypeName="nvarchar(200)")]
                public string Title { get; private set; }
        }
}

/*<Codenesium>
    <Hash>eb39c2a59f5f91fb75e59411593b9ec9</Hash>
</Codenesium>*/