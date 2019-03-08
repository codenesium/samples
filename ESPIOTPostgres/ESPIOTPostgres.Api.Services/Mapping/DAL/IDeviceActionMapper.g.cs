using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial interface IDALDeviceActionMapper
	{
		DeviceAction MapModelToEntity(
			int id,
			ApiDeviceActionServerRequestModel model);

		ApiDeviceActionServerResponseModel MapEntityToModel(
			DeviceAction item);

		List<ApiDeviceActionServerResponseModel> MapEntityToModel(
			List<DeviceAction> items);
	}
}

/*<Codenesium>
    <Hash>ca6619a22b5d626a2e5830b4ba77ca96</Hash>
</Codenesium>*/