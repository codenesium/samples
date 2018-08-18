using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiArtifactRequestModel : AbstractApiRequestModel
	{
		public ApiArtifactRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTimeOffset created,
			string environmentId,
			string filename,
			string jSON,
			string projectId,
			string relatedDocumentIds,
			string tenantId)
		{
			this.Created = created;
			this.EnvironmentId = environmentId;
			this.Filename = filename;
			this.JSON = jSON;
			this.ProjectId = projectId;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.TenantId = tenantId;
		}

		[JsonProperty]
		public DateTimeOffset Created { get; private set; }

		[JsonProperty]
		public string EnvironmentId { get; private set; }

		[JsonProperty]
		public string Filename { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string ProjectId { get; private set; }

		[JsonProperty]
		public string RelatedDocumentIds { get; private set; }

		[JsonProperty]
		public string TenantId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dc7c6fc376e50f7487828267303df069</Hash>
</Codenesium>*/