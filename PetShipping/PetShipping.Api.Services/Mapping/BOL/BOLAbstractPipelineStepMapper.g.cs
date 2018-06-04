using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepMapper
	{
		public virtual BOPipelineStep MapModelToBO(
			int id,
			ApiPipelineStepRequestModel model
			)
		{
			BOPipelineStep BOPipelineStep = new BOPipelineStep();

			BOPipelineStep.SetProperties(
				id,
				model.Name,
				model.PipelineStepStatusId,
				model.ShipperId);
			return BOPipelineStep;
		}

		public virtual ApiPipelineStepResponseModel MapBOToModel(
			BOPipelineStep BOPipelineStep)
		{
			if (BOPipelineStep == null)
			{
				return null;
			}

			var model = new ApiPipelineStepResponseModel();

			model.SetProperties(BOPipelineStep.Id, BOPipelineStep.Name, BOPipelineStep.PipelineStepStatusId, BOPipelineStep.ShipperId);

			return model;
		}

		public virtual List<ApiPipelineStepResponseModel> MapBOToModel(
			List<BOPipelineStep> BOs)
		{
			List<ApiPipelineStepResponseModel> response = new List<ApiPipelineStepResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9cb992b4162b667d002517e95c97de52</Hash>
</Codenesium>*/