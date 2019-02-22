using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALVehicleRefCapabilityMapper
	{
		VehicleRefCapability MapModelToEntity(
			int id,
			ApiVehicleRefCapabilityServerRequestModel model);

		ApiVehicleRefCapabilityServerResponseModel MapEntityToModel(
			VehicleRefCapability item);

		List<ApiVehicleRefCapabilityServerResponseModel> MapEntityToModel(
			List<VehicleRefCapability> items);
	}
}

/*<Codenesium>
    <Hash>85957008b50ef269fe9f83a514b2938d</Hash>
</Codenesium>*/