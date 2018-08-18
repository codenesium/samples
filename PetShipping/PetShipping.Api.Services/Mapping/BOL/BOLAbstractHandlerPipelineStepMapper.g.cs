using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractHandlerPipelineStepMapper
	{
		public virtual BOHandlerPipelineStep MapModelToBO(
			int id,
			ApiHandlerPipelineStepRequestModel model
			)
		{
			BOHandlerPipelineStep boHandlerPipelineStep = new BOHandlerPipelineStep();
			boHandlerPipelineStep.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return boHandlerPipelineStep;
		}

		public virtual ApiHandlerPipelineStepResponseModel MapBOToModel(
			BOHandlerPipelineStep boHandlerPipelineStep)
		{
			var model = new ApiHandlerPipelineStepResponseModel();

			model.SetProperties(boHandlerPipelineStep.Id, boHandlerPipelineStep.HandlerId, boHandlerPipelineStep.PipelineStepId);

			return model;
		}

		public virtual List<ApiHandlerPipelineStepResponseModel> MapBOToModel(
			List<BOHandlerPipelineStep> items)
		{
			List<ApiHandlerPipelineStepResponseModel> response = new List<ApiHandlerPipelineStepResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5094a80e9ef7acc4b855b81b47eb1605</Hash>
</Codenesium>*/