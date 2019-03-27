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
				model.Details,
				model.PipelineStepId,
				model.RequirementMet);
			return item;
		}

		public virtual ApiPipelineStepStepRequirementServerResponseModel MapEntityToModel(
			PipelineStepStepRequirement item)
		{
			var model = new ApiPipelineStepStepRequirementServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Details,
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
    <Hash>88dafe9b1fe51593a736eff25e5805ad</Hash>
</Codenesium>*/