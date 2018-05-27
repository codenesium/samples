using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPipelineStepMapper
	{
		public virtual DTOPipelineStep MapModelToDTO(
			int id,
			ApiPipelineStepRequestModel model
			)
		{
			DTOPipelineStep dtoPipelineStep = new DTOPipelineStep();

			dtoPipelineStep.SetProperties(
				id,
				model.Name,
				model.PipelineStepStatusId,
				model.ShipperId);
			return dtoPipelineStep;
		}

		public virtual ApiPipelineStepResponseModel MapDTOToModel(
			DTOPipelineStep dtoPipelineStep)
		{
			if (dtoPipelineStep == null)
			{
				return null;
			}

			var model = new ApiPipelineStepResponseModel();

			model.SetProperties(dtoPipelineStep.Id, dtoPipelineStep.Name, dtoPipelineStep.PipelineStepStatusId, dtoPipelineStep.ShipperId);

			return model;
		}

		public virtual List<ApiPipelineStepResponseModel> MapDTOToModel(
			List<DTOPipelineStep> dtos)
		{
			List<ApiPipelineStepResponseModel> response = new List<ApiPipelineStepResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>214396d07bad9fb5cbe379d3ed43d6a7</Hash>
</Codenesium>*/