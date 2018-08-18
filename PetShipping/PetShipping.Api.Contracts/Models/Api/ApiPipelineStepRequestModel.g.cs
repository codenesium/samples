using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepRequestModel : AbstractApiRequestModel
	{
		public ApiPipelineStepRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Name = name;
			this.PipelineStepStatusId = pipelineStepStatusId;
			this.ShipperId = shipperId;
		}

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int PipelineStepStatusId { get; private set; }

		[JsonProperty]
		public int ShipperId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f087705971f361dbdf29e006d9e1b13f</Hash>
</Codenesium>*/