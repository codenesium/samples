using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPipelineClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int pipelineStatusId,
			int saleId)
		{
			this.Id = id;
			this.PipelineStatusId = pipelineStatusId;
			this.SaleId = saleId;

			this.PipelineStatusIdEntity = nameof(ApiResponse.PipelineStatus);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PipelineStatusId { get; private set; }

		[JsonProperty]
		public string PipelineStatusIdEntity { get; set; }

		[JsonProperty]
		public int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>871bbb01f4f58b46510e5e47ac7889d2</Hash>
</Codenesium>*/