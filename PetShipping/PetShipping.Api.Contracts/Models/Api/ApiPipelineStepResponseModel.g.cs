using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int PipelineStepStatusId { get; private set; }

		[JsonProperty]
		public string PipelineStepStatusIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public int ShipperId { get; private set; }

		[JsonProperty]
		public string ShipperIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>63fce1b2639d045421d13b6a26f34492</Hash>
</Codenesium>*/