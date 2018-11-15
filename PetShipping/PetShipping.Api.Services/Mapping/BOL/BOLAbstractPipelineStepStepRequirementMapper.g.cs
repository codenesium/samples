using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepStepRequirementMapper
	{
		public virtual BOPipelineStepStepRequirement MapModelToBO(
			int id,
			ApiPipelineStepStepRequirementServerRequestModel model
			)
		{
			BOPipelineStepStepRequirement boPipelineStepStepRequirement = new BOPipelineStepStepRequirement();
			boPipelineStepStepRequirement.SetProperties(
				id,
				model.Detail,
				model.PipelineStepId,
				model.RequirementMet);
			return boPipelineStepStepRequirement;
		}

		public virtual ApiPipelineStepStepRequirementServerResponseModel MapBOToModel(
			BOPipelineStepStepRequirement boPipelineStepStepRequirement)
		{
			var model = new ApiPipelineStepStepRequirementServerResponseModel();

			model.SetProperties(boPipelineStepStepRequirement.Id, boPipelineStepStepRequirement.Detail, boPipelineStepStepRequirement.PipelineStepId, boPipelineStepStepRequirement.RequirementMet);

			return model;
		}

		public virtual List<ApiPipelineStepStepRequirementServerResponseModel> MapBOToModel(
			List<BOPipelineStepStepRequirement> items)
		{
			List<ApiPipelineStepStepRequirementServerResponseModel> response = new List<ApiPipelineStepStepRequirementServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c0927f99d7d099b072849ddabab68f3f</Hash>
</Codenesium>*/