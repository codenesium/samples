using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALOtherTransportMapper
	{
		public virtual OtherTransport MapModelToEntity(
			int id,
			ApiOtherTransportServerRequestModel model
			)
		{
			OtherTransport item = new OtherTransport();
			item.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return item;
		}

		public virtual ApiOtherTransportServerResponseModel MapEntityToModel(
			OtherTransport item)
		{
			var model = new ApiOtherTransportServerResponseModel();

			model.SetProperties(item.Id,
			                    item.HandlerId,
			                    item.PipelineStepId);
			if (item.HandlerIdNavigation != null)
			{
				var handlerIdModel = new ApiHandlerServerResponseModel();
				handlerIdModel.SetProperties(
					item.Id,
					item.HandlerIdNavigation.CountryId,
					item.HandlerIdNavigation.Email,
					item.HandlerIdNavigation.FirstName,
					item.HandlerIdNavigation.LastName,
					item.HandlerIdNavigation.Phone);

				model.SetHandlerIdNavigation(handlerIdModel);
			}

			if (item.PipelineStepIdNavigation != null)
			{
				var pipelineStepIdModel = new ApiPipelineStepServerResponseModel();
				pipelineStepIdModel.SetProperties(
					item.Id,
					item.PipelineStepIdNavigation.Name,
					item.PipelineStepIdNavigation.PipelineStepStatusId,
					item.PipelineStepIdNavigation.ShipperId);

				model.SetPipelineStepIdNavigation(pipelineStepIdModel);
			}

			return model;
		}

		public virtual List<ApiOtherTransportServerResponseModel> MapEntityToModel(
			List<OtherTransport> items)
		{
			List<ApiOtherTransportServerResponseModel> response = new List<ApiOtherTransportServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>71933a610d9f9a82ad4ac84c36fbca29</Hash>
</Codenesium>*/