using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiOtherTransportModel: AbstractModel
	{
		public ApiOtherTransportModel() : base()
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
    <Hash>9f01e22303a21910038907cc7bfb3b85</Hash>
</Codenesium>*/