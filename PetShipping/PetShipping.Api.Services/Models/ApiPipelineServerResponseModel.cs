using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int pipelineStatusId,
			int saleId)
		{
			this.Id = id;
			this.PipelineStatusId = pipelineStatusId;
			this.SaleId = saleId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PipelineStatusId { get; private set; }

		[JsonProperty]
		public string PipelineStatusIdEntity { get; private set; } = RouteConstants.PipelineStatus;

		[JsonProperty]
		public ApiPipelineStatusServerResponseModel PipelineStatusIdNavigation { get; private set; }

		public void SetPipelineStatusIdNavigation(ApiPipelineStatusServerResponseModel value)
		{
			this.PipelineStatusIdNavigation = value;
		}

		[JsonProperty]
		public int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d75b4022db5699150f3b35e0577b39b5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/