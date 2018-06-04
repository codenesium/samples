using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepResponseModel: AbstractApiResponseModel
	{
		public ApiPipelineStepResponseModel() : base()
		{}

		public void SetProperties(
			int id,
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.PipelineStepStatusId = pipelineStepStatusId.ToInt();
			this.ShipperId = shipperId.ToInt();

			this.PipelineStepStatusIdEntity = nameof(ApiResponse.PipelineStepStatus);
			this.ShipperIdEntity = nameof(ApiResponse.Employees);
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public int PipelineStepStatusId { get; private set; }
		public string PipelineStepStatusIdEntity { get; set; }
		public int ShipperId { get; private set; }
		public string ShipperIdEntity { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepStatusIdValue { get; set; } = true;

		public bool ShouldSerializePipelineStepStatusId()
		{
			return this.ShouldSerializePipelineStepStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipperIdValue { get; set; } = true;

		public bool ShouldSerializeShipperId()
		{
			return this.ShouldSerializeShipperIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializePipelineStepStatusIdValue = false;
			this.ShouldSerializeShipperIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>e5f0b1cbd31ae0d8d0ae1d1bbc3fd581</Hash>
</Codenesium>*/