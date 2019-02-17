using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStepDestinationMapper
	{
		public virtual PipelineStepDestination MapModelToEntity(
			int id,
			ApiPipelineStepDestinationServerRequestModel model
			)
		{
			PipelineStepDestination item = new PipelineStepDestination();
			item.SetProperties(
				id,
				model.DestinationId,
				model.PipelineStepId);
			return item;
		}

		public virtual ApiPipelineStepDestinationServerResponseModel MapEntityToModel(
			PipelineStepDestination item)
		{
			var model = new ApiPipelineStepDestinationServerResponseModel();

			model.SetProperties(item.Id,
			                    item.DestinationId,
			                    item.PipelineStepId);
			if (item.DestinationIdNavigation != null)
			{
				var destinationIdModel = new ApiDestinationServerResponseModel();
				destinationIdModel.SetProperties(
					item.DestinationIdNavigation.Id,
					item.DestinationIdNavigation.CountryId,
					item.DestinationIdNavigation.Name,
					item.DestinationIdNavigation.Order);

				model.SetDestinationIdNavigation(destinationIdModel);
			}

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

		public virtual List<ApiPipelineStepDestinationServerResponseModel> MapEntityToModel(
			List<PipelineStepDestination> items)
		{
			List<ApiPipelineStepDestinationServerResponseModel> response = new List<ApiPipelineStepDestinationServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7509f5c14e65302093ebaeeca3e0f4ad</Hash>
</Codenesium>*/