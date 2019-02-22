using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALVehicleRefCapabilityMapper
	{
		public virtual VehicleRefCapability MapModelToEntity(
			int id,
			ApiVehicleRefCapabilityServerRequestModel model
			)
		{
			VehicleRefCapability item = new VehicleRefCapability();
			item.SetProperties(
				id,
				model.VehicleCapabilityId,
				model.VehicleId);
			return item;
		}

		public virtual ApiVehicleRefCapabilityServerResponseModel MapEntityToModel(
			VehicleRefCapability item)
		{
			var model = new ApiVehicleRefCapabilityServerResponseModel();

			model.SetProperties(item.Id,
			                    item.VehicleCapabilityId,
			                    item.VehicleId);
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

		public virtual List<ApiVehicleRefCapabilityServerResponseModel> MapEntityToModel(
			List<VehicleRefCapability> items)
		{
			List<ApiVehicleRefCapabilityServerResponseModel> response = new List<ApiVehicleRefCapabilityServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cc317d59a845bbcbf4e2d92b7305a5c2</Hash>
</Codenesium>*/