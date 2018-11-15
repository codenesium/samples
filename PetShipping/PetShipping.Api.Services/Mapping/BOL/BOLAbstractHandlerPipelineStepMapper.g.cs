using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractHandlerPipelineStepMapper
	{
		public virtual BOHandlerPipelineStep MapModelToBO(
			int id,
			ApiHandlerPipelineStepServerRequestModel model
			)
		{
			BOHandlerPipelineStep boHandlerPipelineStep = new BOHandlerPipelineStep();
			boHandlerPipelineStep.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return boHandlerPipelineStep;
		}

		public virtual ApiHandlerPipelineStepServerResponseModel MapBOToModel(
			BOHandlerPipelineStep boHandlerPipelineStep)
		{
			var model = new ApiHandlerPipelineStepServerResponseModel();

			model.SetProperties(boHandlerPipelineStep.Id, boHandlerPipelineStep.HandlerId, boHandlerPipelineStep.PipelineStepId);

			return model;
		}

		public virtual List<ApiHandlerPipelineStepServerResponseModel> MapBOToModel(
			List<BOHandlerPipelineStep> items)
		{
			List<ApiHandlerPipelineStepServerResponseModel> response = new List<ApiHandlerPipelineStepServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ca0f00220e21f7015938b23846684e20</Hash>
</Codenesium>*/