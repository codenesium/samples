using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepDestinationRequestModel : AbstractApiRequestModel
	{
		public ApiPipelineStepDestinationRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int destinationId,
			int pipelineStepId)
		{
			this.DestinationId = destinationId;
			this.PipelineStepId = pipelineStepId;
		}

		[JsonProperty]
		public int DestinationId { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f7ecae8ed65ea5352d0836de4d169fff</Hash>
</Codenesium>*/