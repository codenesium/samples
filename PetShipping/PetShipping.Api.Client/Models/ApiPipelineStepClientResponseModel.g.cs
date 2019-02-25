using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPipelineStepClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Id = id;
			this.Name = name;
			this.PipelineStepStatusId = pipelineStepStatusId;
			this.ShipperId = shipperId;

			this.PipelineStepStatusIdEntity = nameof(ApiResponse.PipelineStepStatus);

			this.ShipperIdEntity = nameof(ApiResponse.Employees);
		}

		[JsonProperty]
		public ApiPipelineStepStatusClientResponseModel PipelineStepStatusIdNavigation { get; private set; }

		public void SetPipelineStepStatusIdNavigation(ApiPipelineStepStatusClientResponseModel value)
		{
			this.PipelineStepStatusIdNavigation = value;
		}

		[JsonProperty]
		public ApiEmployeeClientResponseModel ShipperIdNavigation { get; private set; }

		public void SetShipperIdNavigation(ApiEmployeeClientResponseModel value)
		{
			this.ShipperIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int PipelineStepStatusId { get; private set; }

		[JsonProperty]
		public string PipelineStepStatusIdEntity { get; set; }

		[JsonProperty]
		public int ShipperId { get; private set; }

		[JsonProperty]
		public string ShipperIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>5695cb138a7b5035c0a893d575c59da5</Hash>
</Codenesium>*/