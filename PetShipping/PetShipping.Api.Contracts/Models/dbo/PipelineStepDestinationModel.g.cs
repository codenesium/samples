using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class PipelineStepDestinationModel
	{
		public PipelineStepDestinationModel()
		{}

		public PipelineStepDestinationModel(
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
    <Hash>4607ba97ec9be2c4a872ea622730d060</Hash>
</Codenesium>*/