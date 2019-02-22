using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALVehicleCapabilityMapper
	{
		public virtual VehicleCapability MapModelToEntity(
			int id,
			ApiVehicleCapabilityServerRequestModel model
			)
		{
			VehicleCapability item = new VehicleCapability();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiVehicleCapabilityServerResponseModel MapEntityToModel(
			VehicleCapability item)
		{
			var model = new ApiVehicleCapabilityServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiVehicleCapabilityServerResponseModel> MapEntityToModel(
			List<VehicleCapability> items)
		{
			List<ApiVehicleCapabilityServerResponseModel> response = new List<ApiVehicleCapabilityServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>288d9947a00331d967ad3c636e8b3d51</Hash>
</Codenesium>*/