using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPipelineStepDestinationMapper
	{
		public virtual DTOPipelineStepDestination MapModelToDTO(
			int id,
			ApiPipelineStepDestinationRequestModel model
			)
		{
			DTOPipelineStepDestination dtoPipelineStepDestination = new DTOPipelineStepDestination();

			dtoPipelineStepDestination.SetProperties(
				id,
				model.DestinationId,
				model.PipelineStepId);
			return dtoPipelineStepDestination;
		}

		public virtual ApiPipelineStepDestinationResponseModel MapDTOToModel(
			DTOPipelineStepDestination dtoPipelineStepDestination)
		{
			if (dtoPipelineStepDestination == null)
			{
				return null;
			}

			var model = new ApiPipelineStepDestinationResponseModel();

			model.SetProperties(dtoPipelineStepDestination.DestinationId, dtoPipelineStepDestination.Id, dtoPipelineStepDestination.PipelineStepId);

			return model;
		}

		public virtual List<ApiPipelineStepDestinationResponseModel> MapDTOToModel(
			List<DTOPipelineStepDestination> dtos)
		{
			List<ApiPipelineStepDestinationResponseModel> response = new List<ApiPipelineStepDestinationResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ef049021e7b69646296295d5e9effb06</Hash>
</Codenesium>*/