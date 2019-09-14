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
		public ApiPipelineStatusClientResponseModel PipelineStatusIdNavigation { get; private set; }

		public void SetPipelineStatusIdNavigation(ApiPipelineStatusClientResponseModel value)
		{
			this.PipelineStatusIdNavigation = value;
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
    <Hash>ff9a7ca9673a1c15d999f6e7d5fd7815</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/