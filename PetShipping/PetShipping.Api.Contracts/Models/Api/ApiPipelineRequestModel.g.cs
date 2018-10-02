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
		public int PipelineStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1c30d62902d5e07bdae8eb567c7fa7bb</Hash>
</Codenesium>*/