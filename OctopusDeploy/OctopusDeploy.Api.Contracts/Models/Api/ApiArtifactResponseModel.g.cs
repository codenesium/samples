using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiArtifactResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			DateTimeOffset created,
			string environmentId,
			string filename,
			string jSON,
			string projectId,
			string relatedDocumentIds,
			string tenantId)
		{
			this.Id = id;
			this.Created = created;
			this.EnvironmentId = environmentId;
			this.Filename = filename;
			this.JSON = jSON;
			this.ProjectId = projectId;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.TenantId = tenantId;
		}

		[Required]
		[JsonProperty]
		public DateTimeOffset Created { get; private set; }

		[Required]
		[JsonProperty]
		public string EnvironmentId { get; private set; }

		[Required]
		[JsonProperty]
		public string Filename { get; private set; }

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
		public string TenantId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f02fcb50ae773ae4d5d0be8e4f05dbc7</Hash>
</Codenesium>*/