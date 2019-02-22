using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALVehicleOfficerMapper
	{
		public virtual VehicleOfficer MapModelToEntity(
			int id,
			ApiVehicleOfficerServerRequestModel model
			)
		{
			VehicleOfficer item = new VehicleOfficer();
			item.SetProperties(
				id,
				model.OfficerId,
				model.VehicleId);
			return item;
		}

		public virtual ApiVehicleOfficerServerResponseModel MapEntityToModel(
			VehicleOfficer item)
		{
			var model = new ApiVehicleOfficerServerResponseModel();

			model.SetProperties(item.Id,
			                    item.OfficerId,
			                    item.VehicleId);
			if (item.OfficerIdNavigation != null)
			{
				var officerIdModel = new ApiOfficerServerResponseModel();
				officerIdModel.SetProperties(
					item.OfficerIdNavigation.Id,
					item.OfficerIdNavigation.Badge,
					item.OfficerIdNavigation.Email,
					item.OfficerIdNavigation.FirstName,
					item.OfficerIdNavigation.LastName,
					item.OfficerIdNavigation.Password);

				model.SetOfficerIdNavigation(officerIdModel);
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

		public virtual List<ApiVehicleOfficerServerResponseModel> MapEntityToModel(
			List<VehicleOfficer> items)
		{
			List<ApiVehicleOfficerServerResponseModel> response = new List<ApiVehicleOfficerServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e688816ec852b5a39a956f9cff3335c2</Hash>
</Codenesium>*/