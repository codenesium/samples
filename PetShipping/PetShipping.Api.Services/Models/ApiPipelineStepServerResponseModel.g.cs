using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineStepServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int PipelineStepStatusId { get; private set; }

		[JsonProperty]
		public string PipelineStepStatusIdEntity { get; private set; } = RouteConstants.PipelineStepStatus;

		[JsonProperty]
		public ApiPipelineStepStatusServerResponseModel PipelineStepStatusIdNavigation { get; private set; }

		public void SetPipelineStepStatusIdNavigation(ApiPipelineStepStatusServerResponseModel value)
		{
			this.PipelineStepStatusIdNavigation = value;
		}

		[JsonProperty]
		public int ShipperId { get; private set; }

		[JsonProperty]
		public string ShipperIdEntity { get; private set; } = RouteConstants.Employees;

		[JsonProperty]
		public ApiEmployeeServerResponseModel ShipperIdNavigation { get; private set; }

		public void SetShipperIdNavigation(ApiEmployeeServerResponseModel value)
		{
			this.ShipperIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>a99d94eb3d41df539390e34416b2f289</Hash>
</Codenesium>*/