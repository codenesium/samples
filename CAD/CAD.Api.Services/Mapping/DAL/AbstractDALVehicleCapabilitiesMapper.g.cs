using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALVehicleCapabilitiesMapper
	{
		public virtual VehicleCapabilities MapModelToEntity(
			int vehicleId,
			ApiVehicleCapabilitiesServerRequestModel model
			)
		{
			VehicleCapabilities item = new VehicleCapabilities();
			item.SetProperties(
				vehicleId,
				model.VehicleCapabilityId);
			return item;
		}

		public virtual ApiVehicleCapabilitiesServerResponseModel MapEntityToModel(
			VehicleCapabilities item)
		{
			var model = new ApiVehicleCapabilitiesServerResponseModel();

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

		public virtual List<ApiVehicleCapabilitiesServerResponseModel> MapEntityToModel(
			List<VehicleCapabilities> items)
		{
			List<ApiVehicleCapabilitiesServerResponseModel> response = new List<ApiVehicleCapabilitiesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>728c8ffd6a3c1b9544c939d5e03c9a48</Hash>
</Codenesium>*/