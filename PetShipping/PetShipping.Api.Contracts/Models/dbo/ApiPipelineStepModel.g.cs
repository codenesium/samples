using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepModel
	{
		public ApiPipelineStepModel()
		{}

		public ApiPipelineStepModel(
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Name = name;
			this.PipelineStepStatusId = pipelineStepStatusId.ToInt();
			this.ShipperId = shipperId.ToInt();
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private int pipelineStepStatusId;

		[Required]
		public int PipelineStepStatusId
		{
			get
			{
				return this.pipelineStepStatusId;
			}

			set
			{
				this.pipelineStepStatusId = value;
			}
		}

		private int shipperId;

		[Required]
		public int ShipperId
		{
			get
			{
				return this.shipperId;
			}

			set
			{
				this.shipperId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>618cd7ec0cd0a87ce36ad97f83ee7d0c</Hash>
</Codenesium>*/