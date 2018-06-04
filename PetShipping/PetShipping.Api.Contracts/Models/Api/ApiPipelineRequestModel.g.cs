using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineRequestModel: AbstractApiRequestModel
	{
		public ApiPipelineRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>eaee5ebfbd04294bfb8a8b4fb9449ac8</Hash>
</Codenesium>*/