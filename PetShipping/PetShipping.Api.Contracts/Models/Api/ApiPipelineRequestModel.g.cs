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

		[JsonProperty]
		public int PipelineStatusId { get; private set; }

		[JsonProperty]
		public int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>537c34980caaaf1bfc77203807574dce</Hash>
</Codenesium>*/