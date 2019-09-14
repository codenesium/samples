using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALVehicleOfficerMapper
	{
		VehicleOfficer MapModelToEntity(
			int id,
			ApiVehicleOfficerServerRequestModel model);

		ApiVehicleOfficerServerResponseModel MapEntityToModel(
			VehicleOfficer item);

		List<ApiVehicleOfficerServerResponseModel> MapEntityToModel(
			List<VehicleOfficer> items);
	}
}

/*<Codenesium>
    <Hash>fc4b530db3ffa4037880075d720eeda9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/