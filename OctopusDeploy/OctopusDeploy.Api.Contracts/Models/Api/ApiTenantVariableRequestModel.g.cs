using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiTenantVariableRequestModel : AbstractApiRequestModel
	{
		public ApiTenantVariableRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string environmentId,
			string jSON,
			string ownerId,
			string relatedDocumentId,
			string tenantId,
			string variableTemplateId)
		{
			this.EnvironmentId = environmentId;
			this.JSON = jSON;
			this.OwnerId = ownerId;
			this.RelatedDocumentId = relatedDocumentId;
			this.TenantId = tenantId;
			this.VariableTemplateId = variableTemplateId;
		}

		[JsonProperty]
		public string EnvironmentId { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string OwnerId { get; private set; }

		[JsonProperty]
		public string RelatedDocumentId { get; private set; }

		[JsonProperty]
		public string TenantId { get; private set; }

		[JsonProperty]
		public string VariableTemplateId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5fa3e209fdfc414cdfb4c98669c8fa44</Hash>
</Codenesium>*/