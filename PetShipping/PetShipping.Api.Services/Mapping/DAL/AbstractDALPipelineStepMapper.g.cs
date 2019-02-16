using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStepMapper
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
				var pipelineStepStatusIdModel = new ApiPipelineStepStatuServerResponseModel();
				pipelineStepStatusIdModel.SetProperties(
					item.Id,
					item.PipelineStepStatusIdNavigation.Name);

				model.SetPipelineStepStatusIdNavigation(pipelineStepStatusIdModel);
			}

			if (item.ShipperIdNavigation != null)
			{
				var shipperIdModel = new ApiEmployeeServerResponseModel();
				shipperIdModel.SetProperties(
					item.Id,
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
    <Hash>db2d62bed3c467d809bcf35ecdd86055</Hash>
</Codenesium>*/