using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLHandlerPipelineStepMapper
	{
		public virtual DTOHandlerPipelineStep MapModelToDTO(
			int id,
			ApiHandlerPipelineStepRequestModel model
			)
		{
			DTOHandlerPipelineStep dtoHandlerPipelineStep = new DTOHandlerPipelineStep();

			dtoHandlerPipelineStep.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return dtoHandlerPipelineStep;
		}

		public virtual ApiHandlerPipelineStepResponseModel MapDTOToModel(
			DTOHandlerPipelineStep dtoHandlerPipelineStep)
		{
			if (dtoHandlerPipelineStep == null)
			{
				return null;
			}

			var model = new ApiHandlerPipelineStepResponseModel();

			model.SetProperties(dtoHandlerPipelineStep.HandlerId, dtoHandlerPipelineStep.Id, dtoHandlerPipelineStep.PipelineStepId);

			return model;
		}

		public virtual List<ApiHandlerPipelineStepResponseModel> MapDTOToModel(
			List<DTOHandlerPipelineStep> dtos)
		{
			List<ApiHandlerPipelineStepResponseModel> response = new List<ApiHandlerPipelineStepResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>205670634fe5db2c9e3cafef280a5445</Hash>
</Codenesium>*/