using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public int PipelineStepStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public int ShipperId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>821f1fd285a40547fd05641d1ccb9ca5</Hash>
</Codenesium>*/