using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStepStepRequirementMapper
	{
		public virtual PipelineStepStepRequirement MapModelToEntity(
			int id,
			ApiPipelineStepStepRequirementServerRequestModel model
			)
		{
			PipelineStepStepRequirement item = new PipelineStepStepRequirement();
			item.SetProperties(
				id,
				model.Detail,
				model.PipelineStepId,
				model.RequirementMet);
			return item;
		}

		public virtual ApiPipelineStepStepRequirementServerResponseModel MapEntityToModel(
			PipelineStepStepRequirement item)
		{
			var model = new ApiPipelineStepStepRequirementServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Detail,
			                    item.PipelineStepId,
			                    item.RequirementMet);
			if (item.PipelineStepIdNavigation != null)
			{
				var pipelineStepIdModel = new ApiPipelineStepServerResponseModel();
				pipelineStepIdModel.SetProperties(
					item.PipelineStepIdNavigation.Id,
					item.PipelineStepIdNavigation.Name,
					item.PipelineStepIdNavigation.PipelineStepStatusId,
					item.PipelineStepIdNavigation.ShipperId);

				model.SetPipelineStepIdNavigation(pipelineStepIdModel);
			}

			return model;
		}

		public virtual List<ApiPipelineStepStepRequirementServerResponseModel> MapEntityToModel(
			List<PipelineStepStepRequirement> items)
		{
			List<ApiPipelineStepStepRequirementServerResponseModel> response = new List<ApiPipelineStepStepRequirementServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f5af32e081a9c253f7e273bf3397dc34</Hash>
</Codenesium>*/