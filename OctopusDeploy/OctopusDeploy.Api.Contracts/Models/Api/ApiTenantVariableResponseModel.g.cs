using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiTenantVariableResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string environmentId,
			string jSON,
			string ownerId,
			string relatedDocumentId,
			string tenantId,
			string variableTemplateId)
		{
			this.Id = id;
			this.EnvironmentId = environmentId;
			this.JSON = jSON;
			this.OwnerId = ownerId;
			this.RelatedDocumentId = relatedDocumentId;
			this.TenantId = tenantId;
			this.VariableTemplateId = variableTemplateId;
		}

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
		public string OwnerId { get; private set; }

		[Required]
		[JsonProperty]
		public string RelatedDocumentId { get; private set; }

		[Required]
		[JsonProperty]
		public string TenantId { get; private set; }

		[Required]
		[JsonProperty]
		public string VariableTemplateId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>67267f9f105fbe2fb7f9897f816ba45b</Hash>
</Codenesium>*/