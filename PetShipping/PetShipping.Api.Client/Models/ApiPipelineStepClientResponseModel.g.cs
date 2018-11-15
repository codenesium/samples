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
    <Hash>dad988aaa8b1e1b0a50fd8bfacfa2786</Hash>
</Codenesium>*/