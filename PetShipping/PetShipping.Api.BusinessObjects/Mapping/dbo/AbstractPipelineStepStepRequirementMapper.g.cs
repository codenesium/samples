using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPipelineStepStepRequirementMapper
	{
		public virtual DTOPipelineStepStepRequirement MapModelToDTO(
			int id,
			ApiPipelineStepStepRequirementRequestModel model
			)
		{
			DTOPipelineStepStepRequirement dtoPipelineStepStepRequirement = new DTOPipelineStepStepRequirement();

			dtoPipelineStepStepRequirement.SetProperties(
				id,
				model.Details,
				model.PipelineStepId,
				model.RequirementMet);
			return dtoPipelineStepStepRequirement;
		}

		public virtual ApiPipelineStepStepRequirementResponseModel MapDTOToModel(
			DTOPipelineStepStepRequirement dtoPipelineStepStepRequirement)
		{
			if (dtoPipelineStepStepRequirement == null)
			{
				return null;
			}

			var model = new ApiPipelineStepStepRequirementResponseModel();

			model.SetProperties(dtoPipelineStepStepRequirement.Details, dtoPipelineStepStepRequirement.Id, dtoPipelineStepStepRequirement.PipelineStepId, dtoPipelineStepStepRequirement.RequirementMet);

			return model;
		}

		public virtual List<ApiPipelineStepStepRequirementResponseModel> MapDTOToModel(
			List<DTOPipelineStepStepRequirement> dtos)
		{
			List<ApiPipelineStepStepRequirementResponseModel> response = new List<ApiPipelineStepStepRequirementResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a10445e991a980a3e846956b526f7e40</Hash>
</Codenesium>*/