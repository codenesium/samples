using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepMapper
	{
		public virtual BOPipelineStep MapModelToBO(
			int id,
			ApiPipelineStepServerRequestModel model
			)
		{
			BOPipelineStep boPipelineStep = new BOPipelineStep();
			boPipelineStep.SetProperties(
				id,
				model.Name,
				model.PipelineStepStatusId,
				model.ShipperId);
			return boPipelineStep;
		}

		public virtual ApiPipelineStepServerResponseModel MapBOToModel(
			BOPipelineStep boPipelineStep)
		{
			var model = new ApiPipelineStepServerResponseModel();

			model.SetProperties(boPipelineStep.Id, boPipelineStep.Name, boPipelineStep.PipelineStepStatusId, boPipelineStep.ShipperId);

			return model;
		}

		public virtual List<ApiPipelineStepServerResponseModel> MapBOToModel(
			List<BOPipelineStep> items)
		{
			List<ApiPipelineStepServerResponseModel> response = new List<ApiPipelineStepServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>156a2982144df80f98b97901ac3ffcf0</Hash>
</Codenesium>*/