using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALVehicleCapabilitiesMapper
	{
		VehicleCapabilities MapModelToEntity(
			int vehicleId,
			ApiVehicleCapabilitiesServerRequestModel model);

		ApiVehicleCapabilitiesServerResponseModel MapEntityToModel(
			VehicleCapabilities item);

		List<ApiVehicleCapabilitiesServerResponseModel> MapEntityToModel(
			List<VehicleCapabilities> items);
	}
}

/*<Codenesium>
    <Hash>65dc4ddb22ba4abe62c4f2658b7d604f</Hash>
</Codenesium>*/