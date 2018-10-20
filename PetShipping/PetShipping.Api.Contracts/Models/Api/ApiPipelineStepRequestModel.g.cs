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

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PipelineStepStatusId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int ShipperId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>beeb1e29db9b7e92a86b8e98aa558cd0</Hash>
</Codenesium>*/