using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiHandlerPipelineStepServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiHandlerPipelineStepServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int handlerId,
			int pipelineStepId)
		{
			this.HandlerId = handlerId;
			this.PipelineStepId = pipelineStepId;
		}

		[Required]
		[JsonProperty]
		public int HandlerId { get; private set; }

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bd0b8f584976d7243084560ab87a722e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/