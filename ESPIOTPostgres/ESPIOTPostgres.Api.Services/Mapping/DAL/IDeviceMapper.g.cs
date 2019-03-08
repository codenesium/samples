using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial interface IDALDeviceMapper
	{
		Device MapModelToEntity(
			int id,
			ApiDeviceServerRequestModel model);

		ApiDeviceServerResponseModel MapEntityToModel(
			Device item);

		List<ApiDeviceServerResponseModel> MapEntityToModel(
			List<Device> items);
	}
}

/*<Codenesium>
    <Hash>bbdc3e0a35997d6505fa8697681b9dca</Hash>
</Codenesium>*/