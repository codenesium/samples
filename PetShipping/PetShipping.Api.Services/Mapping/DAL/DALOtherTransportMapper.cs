using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALOtherTransportMapper : IDALOtherTransportMapper
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
					item.HandlerIdNavigation.Id,
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
					item.PipelineStepIdNavigation.Id,
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
    <Hash>ca5afb5d3ba68047f62ec8a499b1fff2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/