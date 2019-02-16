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
		public ApiPipelineStepStatuServerResponseModel PipelineStepStatusIdNavigation { get; private set; }

		public void SetPipelineStepStatusIdNavigation(ApiPipelineStepStatuServerResponseModel value)
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
    <Hash>36bc62aa2e20438eaae37ad0b39072e7</Hash>
</Codenesium>*/