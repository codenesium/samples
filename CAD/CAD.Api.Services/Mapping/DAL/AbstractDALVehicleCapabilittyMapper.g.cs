using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALVehicleCapabilittyMapper
	{
		public virtual VehicleCapabilitty MapModelToEntity(
			int vehicleId,
			ApiVehicleCapabilittyServerRequestModel model
			)
		{
			VehicleCapabilitty item = new VehicleCapabilitty();
			item.SetProperties(
				vehicleId,
				model.VehicleCapabilityId);
			return item;
		}

		public virtual ApiVehicleCapabilittyServerResponseModel MapEntityToModel(
			VehicleCapabilitty item)
		{
			var model = new ApiVehicleCapabilittyServerResponseModel();

			model.SetProperties(item.VehicleId,
			                    item.VehicleCapabilityId);
			if (item.VehicleCapabilityIdNavigation != null)
			{
				var vehicleCapabilityIdModel = new ApiVehicleCapabilityServerResponseModel();
				vehicleCapabilityIdModel.SetProperties(
					item.VehicleCapabilityIdNavigation.Id,
					item.VehicleCapabilityIdNavigation.Name);

				model.SetVehicleCapabilityIdNavigation(vehicleCapabilityIdModel);
			}

			if (item.VehicleIdNavigation != null)
			{
				var vehicleIdModel = new ApiVehicleServerResponseModel();
				vehicleIdModel.SetProperties(
					item.VehicleIdNavigation.Id,
					item.VehicleIdNavigation.Name);

				model.SetVehicleIdNavigation(vehicleIdModel);
			}

			return model;
		}

		public virtual List<ApiVehicleCapabilittyServerResponseModel> MapEntityToModel(
			List<VehicleCapabilitty> items)
		{
			List<ApiVehicleCapabilittyServerResponseModel> response = new List<ApiVehicleCapabilittyServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>caf1f23b858bddcb7df5898cceea5e90</Hash>
</Codenesium>*/