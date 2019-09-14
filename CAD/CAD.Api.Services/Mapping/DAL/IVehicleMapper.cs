using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALVehicleMapper
	{
		Vehicle MapModelToEntity(
			int id,
			ApiVehicleServerRequestModel model);

		ApiVehicleServerResponseModel MapEntityToModel(
			Vehicle item);

		List<ApiVehicleServerResponseModel> MapEntityToModel(
			List<Vehicle> items);
	}
}

/*<Codenesium>
    <Hash>30ba881afb8425a9aa54a1d8ed69b512</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/