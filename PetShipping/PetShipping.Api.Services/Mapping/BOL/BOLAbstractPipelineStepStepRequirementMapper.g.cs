using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepStepRequirementMapper
	{
		public virtual BOPipelineStepStepRequirement MapModelToBO(
			int id,
			ApiPipelineStepStepRequirementRequestModel model
			)
		{
			BOPipelineStepStepRequirement BOPipelineStepStepRequirement = new BOPipelineStepStepRequirement();

			BOPipelineStepStepRequirement.SetProperties(
				id,
				model.Details,
				model.PipelineStepId,
				model.RequirementMet);
			return BOPipelineStepStepRequirement;
		}

		public virtual ApiPipelineStepStepRequirementResponseModel MapBOToModel(
			BOPipelineStepStepRequirement BOPipelineStepStepRequirement)
		{
			if (BOPipelineStepStepRequirement == null)
			{
				return null;
			}

			var model = new ApiPipelineStepStepRequirementResponseModel();

			model.SetProperties(BOPipelineStepStepRequirement.Details, BOPipelineStepStepRequirement.Id, BOPipelineStepStepRequirement.PipelineStepId, BOPipelineStepStepRequirement.RequirementMet);

			return model;
		}

		public virtual List<ApiPipelineStepStepRequirementResponseModel> MapBOToModel(
			List<BOPipelineStepStepRequirement> BOs)
		{
			List<ApiPipelineStepStepRequirementResponseModel> response = new List<ApiPipelineStepStepRequirementResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ea42c71492a5511349b4040200db73db</Hash>
</Codenesium>*/