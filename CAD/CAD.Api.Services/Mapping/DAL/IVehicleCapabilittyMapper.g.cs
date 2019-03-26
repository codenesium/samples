using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALVehicleCapabilittyMapper
	{
		VehicleCapabilitty MapModelToEntity(
			int vehicleId,
			ApiVehicleCapabilittyServerRequestModel model);

		ApiVehicleCapabilittyServerResponseModel MapEntityToModel(
			VehicleCapabilitty item);

		List<ApiVehicleCapabilittyServerResponseModel> MapEntityToModel(
			List<VehicleCapabilitty> items);
	}
}

/*<Codenesium>
    <Hash>21f91564755078924cca7852ce6d26aa</Hash>
</Codenesium>*/