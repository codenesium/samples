using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiEventResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			long autoId,
			string category,
			string environmentId,
			string jSON,
			string message,
			DateTimeOffset occurred,
			string projectId,
			string relatedDocumentIds,
			string tenantId,
			string userId,
			string username)
		{
			this.Id = id;
			this.AutoId = autoId;
			this.Category = category;
			this.EnvironmentId = environmentId;
			this.JSON = jSON;
			this.Message = message;
			this.Occurred = occurred;
			this.ProjectId = projectId;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.TenantId = tenantId;
			this.UserId = userId;
			this.Username = username;
		}

		[Required]
		[JsonProperty]
		public long AutoId { get; private set; }

		[Required]
		[JsonProperty]
		public string Category { get; private set; }

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
		public string Message { get; private set; }

		[Required]
		[JsonProperty]
		public DateTimeOffset Occurred { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectId { get; private set; }

		[Required]
		[JsonProperty]
		public string RelatedDocumentIds { get; private set; }

		[Required]
		[JsonProperty]
		public string TenantId { get; private set; }

		[Required]
		[JsonProperty]
		public string UserId { get; private set; }

		[Required]
		[JsonProperty]
		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>594bca0ba088b9e15352854761d37666</Hash>
</Codenesium>*/