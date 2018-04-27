using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class PipelineModel
	{
		public PipelineModel()
		{}

		public PipelineModel(
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
    <Hash>0464c41c526d71a7a41266e821ac6988</Hash>
</Codenesium>*/