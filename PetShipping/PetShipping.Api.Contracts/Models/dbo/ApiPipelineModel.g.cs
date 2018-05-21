using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineModel: AbstractModel
	{
		public ApiPipelineModel() : base()
		{}

		public ApiPipelineModel(
			int pipelineStatusId,
			int saleId)
		{
			this.PipelineStatusId = pipelineStatusId.ToInt();
			this.SaleId = saleId.ToInt();
		}

		private int pipelineStatusId;

		[Required]
		public int PipelineStatusId
		{
			get
			{
				return this.pipelineStatusId;
			}

			set
			{
				this.pipelineStatusId = value;
			}
		}

		private int saleId;

		[Required]
		public int SaleId
		{
			get
			{
				return this.saleId;
			}

			set
			{
				this.saleId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>801b88919ce366d4c8aabeecab60f0e5</Hash>
</Codenesium>*/