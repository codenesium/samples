using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiOtherTransportModel
	{
		public ApiOtherTransportModel()
		{}

		public ApiOtherTransportModel(
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
    <Hash>9a0cbc2ddb3a85971b9b7743c7029521</Hash>
</Codenesium>*/