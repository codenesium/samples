using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALVehicleCapabilitiesMapper
	{
		public virtual VehicleCapabilities MapModelToEntity(
			int id,
			ApiVehicleCapabilitiesServerRequestModel model
			)
		{
			VehicleCapabilities item = new VehicleCapabilities();
			item.SetProperties(
				id,
				model.VehicleCapabilityId,
				model.VehicleId);
			return item;
		}

		public virtual ApiVehicleCapabilitiesServerResponseModel MapEntityToModel(
			VehicleCapabilities item)
		{
			var model = new ApiVehicleCapabilitiesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.VehicleCapabilityId,
			                    item.VehicleId);
			if (item.VehicleCapabilityIdNavigation != null)
			{
				var vehicleCapabilityIdModel = new ApiVehCapabilityServerResponseModel();
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
    <Hash>4409a09f7d511cb0955f984586d97ca6</Hash>
</Codenesium>*/