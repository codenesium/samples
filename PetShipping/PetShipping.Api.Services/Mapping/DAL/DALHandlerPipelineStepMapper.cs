using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALHandlerPipelineStepMapper : IDALHandlerPipelineStepMapper
	{
		public virtual HandlerPipelineStep MapModelToEntity(
			int id,
			ApiHandlerPipelineStepServerRequestModel model
			)
		{
			HandlerPipelineStep item = new HandlerPipelineStep();
			item.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return item;
		}

		public virtual ApiHandlerPipelineStepServerResponseModel MapEntityToModel(
			HandlerPipelineStep item)
		{
			var model = new ApiHandlerPipelineStepServerResponseModel();

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

		public virtual List<ApiHandlerPipelineStepServerResponseModel> MapEntityToModel(
			List<HandlerPipelineStep> items)
		{
			List<ApiHandlerPipelineStepServerResponseModel> response = new List<ApiHandlerPipelineStepServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5186fa91934d9923e0081ab30b4a5f72</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/