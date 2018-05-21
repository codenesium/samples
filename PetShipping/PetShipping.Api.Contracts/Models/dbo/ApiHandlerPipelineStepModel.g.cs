using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiHandlerPipelineStepModel: AbstractModel
	{
		public ApiHandlerPipelineStepModel() : base()
		{}

		public ApiHandlerPipelineStepModel(
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
    <Hash>c8d5173ccd2f4bb555a1376b72aec132</Hash>
</Codenesium>*/