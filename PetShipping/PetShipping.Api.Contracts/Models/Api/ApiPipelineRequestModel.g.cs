using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public int PipelineStatusId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int SaleId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>3a07a561d3ee481a0082b771c296b48c</Hash>
</Codenesium>*/