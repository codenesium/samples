using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineStepServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPipelineStepServerRequestModel()
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
		public int PipelineStepStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public int ShipperId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8a7440c8d32d2a7b7a24ac797d460cd0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/