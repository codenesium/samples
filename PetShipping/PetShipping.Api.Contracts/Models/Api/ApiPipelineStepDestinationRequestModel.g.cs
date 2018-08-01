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
    <Hash>4d46866fbf0d472dbced3be2054de633</Hash>
</Codenesium>*/