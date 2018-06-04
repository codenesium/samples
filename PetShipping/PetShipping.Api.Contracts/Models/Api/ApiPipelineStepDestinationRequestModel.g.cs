using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepDestinationRequestModel: AbstractApiRequestModel
	{
		public ApiPipelineStepDestinationRequestModel() : base()
		{}

		public void SetProperties(
			int destinationId,
			int pipelineStepId)
		{
			this.DestinationId = destinationId.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		private int destinationId;

		[Required]
		public int DestinationId
		{
			get
			{
				return this.destinationId;
			}

			set
			{
				this.destinationId = value;
			}
		}

		private int pipelineStepId;

		[Required]
		public int PipelineStepId
		{
			get
			{
				return this.pipelineStepId;
			}

			set
			{
				this.pipelineStepId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>45de9d1a16f6a86f3cd9dc8569d16896</Hash>
</Codenesium>*/