using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public interface IBOLDeviceActionMapper
	{
		BODeviceAction MapModelToBO(
			int id,
			ApiDeviceActionRequestModel model);

		ApiDeviceActionResponseModel MapBOToModel(
			BODeviceAction boDeviceAction);

		List<ApiDeviceActionResponseModel> MapBOToModel(
			List<BODeviceAction> items);
	}
}

/*<Codenesium>
    <Hash>9f076b885a5ea5d79105b0dae90a5969</Hash>
</Codenesium>*/