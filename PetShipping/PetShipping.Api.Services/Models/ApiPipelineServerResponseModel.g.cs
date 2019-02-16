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
		public ApiPipelineStatuServerResponseModel PipelineStatusIdNavigation { get; private set; }

		public void SetPipelineStatusIdNavigation(ApiPipelineStatuServerResponseModel value)
		{
			this.PipelineStatusIdNavigation = value;
		}

		[JsonProperty]
		public int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cc541cf7cb4ae66c0b81d9b96840dcb8</Hash>
</Codenesium>*/