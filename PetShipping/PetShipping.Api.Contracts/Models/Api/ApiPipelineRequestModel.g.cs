using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineRequestModel : AbstractApiRequestModel
	{
		public ApiPipelineRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int pipelineStatusId,
			int saleId)
		{
			this.PipelineStatusId = pipelineStatusId;
			this.SaleId = saleId;
		}

		[Required]
		[JsonProperty]
		public int PipelineStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public int SaleId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>9d52537202f2019f33927d6dc9fcd765</Hash>
</Codenesium>*/