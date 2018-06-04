using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractHandlerPipelineStepMapper
	{
		public virtual BOHandlerPipelineStep MapModelToBO(
			int id,
			ApiHandlerPipelineStepRequestModel model
			)
		{
			BOHandlerPipelineStep BOHandlerPipelineStep = new BOHandlerPipelineStep();

			BOHandlerPipelineStep.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return BOHandlerPipelineStep;
		}

		public virtual ApiHandlerPipelineStepResponseModel MapBOToModel(
			BOHandlerPipelineStep BOHandlerPipelineStep)
		{
			if (BOHandlerPipelineStep == null)
			{
				return null;
			}

			var model = new ApiHandlerPipelineStepResponseModel();

			model.SetProperties(BOHandlerPipelineStep.HandlerId, BOHandlerPipelineStep.Id, BOHandlerPipelineStep.PipelineStepId);

			return model;
		}

		public virtual List<ApiHandlerPipelineStepResponseModel> MapBOToModel(
			List<BOHandlerPipelineStep> BOs)
		{
			List<ApiHandlerPipelineStepResponseModel> response = new List<ApiHandlerPipelineStepResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a30d43e100ea06b6dbae24a380ef3324</Hash>
</Codenesium>*/