using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineStepDestinationServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPipelineStepDestinationServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int DestinationId { get; private set; }

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f8e1caa9addae7880ea1ff12471f519c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/