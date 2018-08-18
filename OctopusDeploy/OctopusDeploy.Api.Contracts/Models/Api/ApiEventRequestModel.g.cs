using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiEventRequestModel : AbstractApiRequestModel
	{
		public ApiEventRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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

		[JsonProperty]
		public long AutoId { get; private set; }

		[JsonProperty]
		public string Category { get; private set; }

		[JsonProperty]
		public string EnvironmentId { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Message { get; private set; }

		[JsonProperty]
		public DateTimeOffset Occurred { get; private set; }

		[JsonProperty]
		public string ProjectId { get; private set; }

		[JsonProperty]
		public string RelatedDocumentIds { get; private set; }

		[JsonProperty]
		public string TenantId { get; private set; }

		[JsonProperty]
		public string UserId { get; private set; }

		[JsonProperty]
		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>87abf6b0a87acf7211bdbbe0316502f0</Hash>
</Codenesium>*/