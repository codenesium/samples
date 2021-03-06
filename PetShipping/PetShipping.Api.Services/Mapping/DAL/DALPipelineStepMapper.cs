using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALPipelineStepMapper : IDALPipelineStepMapper
	{
		public virtual PipelineStep MapModelToEntity(
			int id,
			ApiPipelineStepServerRequestModel model
			)
		{
			PipelineStep item = new PipelineStep();
			item.SetProperties(
				id,
				model.Name,
				model.PipelineStepStatusId,
				model.ShipperId);
			return item;
		}

		public virtual ApiPipelineStepServerResponseModel MapEntityToModel(
			PipelineStep item)
		{
			var model = new ApiPipelineStepServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.PipelineStepStatusId,
			                    item.ShipperId);
			if (item.PipelineStepStatusIdNavigation != null)
			{
				var pipelineStepStatusIdModel = new ApiPipelineStepStatusServerResponseModel();
				pipelineStepStatusIdModel.SetProperties(
					item.PipelineStepStatusIdNavigation.Id,
					item.PipelineStepStatusIdNavigation.Name);

				model.SetPipelineStepStatusIdNavigation(pipelineStepStatusIdModel);
			}

			if (item.ShipperIdNavigation != null)
			{
				var shipperIdModel = new ApiEmployeeServerResponseModel();
				shipperIdModel.SetProperties(
					item.ShipperIdNavigation.Id,
					item.ShipperIdNavigation.FirstName,
					item.ShipperIdNavigation.IsSalesPerson,
					item.ShipperIdNavigation.IsShipper,
					item.ShipperIdNavigation.LastName);

				model.SetShipperIdNavigation(shipperIdModel);
			}

			return model;
		}

		public virtual List<ApiPipelineStepServerResponseModel> MapEntityToModel(
			List<PipelineStep> items)
		{
			List<ApiPipelineStepServerResponseModel> response = new List<ApiPipelineStepServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7a4eb33ff470d39c3e87ba384610df4d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/