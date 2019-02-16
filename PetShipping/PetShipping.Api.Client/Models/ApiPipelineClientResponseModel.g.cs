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
		public ApiPipelineStatuClientResponseModel PipelineStatusIdNavigation { get; private set; }

		public void SetPipelineStatusIdNavigation(ApiPipelineStatuClientResponseModel value)
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
    <Hash>498bf3063ff6589513cdf6a3b15a197f</Hash>
</Codenesium>*/