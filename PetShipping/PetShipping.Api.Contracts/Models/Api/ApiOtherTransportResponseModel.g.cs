using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiOtherTransportResponseModel: AbstractApiResponseModel
	{
		public ApiOtherTransportResponseModel() : base()
		{}

		public void SetProperties(
			int handlerId,
			int id,
			int pipelineStepId)
		{
			this.HandlerId = handlerId.ToInt();
			this.Id = id.ToInt();
			this.PipelineStepId = pipelineStepId.ToInt();

			this.HandlerIdEntity = nameof(ApiResponse.Handlers);
			this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
		}

		public int HandlerId { get; private set; }
		public string HandlerIdEntity { get; set; }
		public int Id { get; private set; }
		public int PipelineStepId { get; private set; }
		public string PipelineStepIdEntity { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeHandlerIdValue { get; set; } = true;

		public bool ShouldSerializeHandlerId()
		{
			return this.ShouldSerializeHandlerIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepIdValue { get; set; } = true;

		public bool ShouldSerializePipelineStepId()
		{
			return this.ShouldSerializePipelineStepIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeHandlerIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializePipelineStepIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>02a3edeac3d544ede050d88607a34b49</Hash>
</Codenesium>*/