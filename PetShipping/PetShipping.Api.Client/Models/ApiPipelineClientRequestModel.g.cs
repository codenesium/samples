using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPipelineClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPipelineClientRequestModel()
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
		public int SaleId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>8aba7babbf10592aec8a7bec2e36760b</Hash>
</Codenesium>*/