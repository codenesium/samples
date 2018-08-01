using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Interruption", Schema="dbo")]
	public partial class Interruption : AbstractEntity
	{
		public Interruption()
		{
		}

		public virtual void SetProperties(
			DateTimeOffset created,
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

		[Column("Created")]
		public DateTimeOffset Created { get; private set; }

		[Column("EnvironmentId")]
		public string EnvironmentId { get; private set; }

		[Key]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("ProjectId")]
		public string ProjectId { get; private set; }

		[Column("RelatedDocumentIds")]
		public string RelatedDocumentIds { get; private set; }

		[Column("ResponsibleTeamIds")]
		public string ResponsibleTeamIds { get; private set; }

		[Column("Status")]
		public string Status { get; private set; }

		[Column("TaskId")]
		public string TaskId { get; private set; }

		[Column("TenantId")]
		public string TenantId { get; private set; }

		[Column("Title")]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>41def437081c38ade653721be4e81a8c</Hash>
</Codenesium>*/