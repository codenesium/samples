using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiInterruptionResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			DateTimeOffset created,
			string environmentId,
			string jSON,
			string projectId,
			string relatedDocumentIds,
			string responsibleTeamIds,
			string status,
			string taskId,
			string tenantId,
			string title)
		{
			this.Id = id;
			this.Created = created;
			this.EnvironmentId = environmentId;
			this.JSON = jSON;
			this.ProjectId = projectId;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.ResponsibleTeamIds = responsibleTeamIds;
			this.Status = status;
			this.TaskId = taskId;
			this.TenantId = tenantId;
			this.Title = title;
		}

		[Required]
		[JsonProperty]
		public DateTimeOffset Created { get; private set; }

		[Required]
		[JsonProperty]
		public string EnvironmentId { get; private set; }

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectId { get; private set; }

		[Required]
		[JsonProperty]
		public string RelatedDocumentIds { get; private set; }

		[Required]
		[JsonProperty]
		public string ResponsibleTeamIds { get; private set; }

		[Required]
		[JsonProperty]
		public string Status { get; private set; }

		[Required]
		[JsonProperty]
		public string TaskId { get; private set; }

		[Required]
		[JsonProperty]
		public string TenantId { get; private set; }

		[Required]
		[JsonProperty]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2516b50fd7197e10e54a1fff914a9170</Hash>
</Codenesium>*/