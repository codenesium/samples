using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALVehicleCapabilityMapper
	{
		VehicleCapability MapModelToEntity(
			int id,
			ApiVehicleCapabilityServerRequestModel model);

		ApiVehicleCapabilityServerResponseModel MapEntityToModel(
			VehicleCapability item);

		List<ApiVehicleCapabilityServerResponseModel> MapEntityToModel(
			List<VehicleCapability> items);
	}
}

/*<Codenesium>
    <Hash>fefd97baec5f163d7845e3919c6fd922</Hash>
</Codenesium>*/