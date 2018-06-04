using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiHandlerPipelineStepRequestModel: AbstractApiRequestModel
	{
		public ApiHandlerPipelineStepRequestModel() : base()
		{}

		public void SetProperties(
			int handlerId,
			int pipelineStepId)
		{
			this.HandlerId = handlerId.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		private int handlerId;

		[Required]
		public int HandlerId
		{
			get
			{
				return this.handlerId;
			}

			set
			{
				this.handlerId = value;
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
    <Hash>4f0cb6730acb83114e3c42746d93cc4a</Hash>
</Codenesium>*/