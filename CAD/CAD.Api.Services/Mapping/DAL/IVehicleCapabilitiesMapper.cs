using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALVehicleCapabilitiesMapper
	{
		VehicleCapabilities MapModelToEntity(
			int id,
			ApiVehicleCapabilitiesServerRequestModel model);

		ApiVehicleCapabilitiesServerResponseModel MapEntityToModel(
			VehicleCapabilities item);

		List<ApiVehicleCapabilitiesServerResponseModel> MapEntityToModel(
			List<VehicleCapabilities> items);
	}
}

/*<Codenesium>
    <Hash>9462f11378dcead1296bec658f7e0486</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/