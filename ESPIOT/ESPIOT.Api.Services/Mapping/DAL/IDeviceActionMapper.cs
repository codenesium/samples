using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
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
    <Hash>0c4eedd16ea2dbd0a1c5de3f5c103a65</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/