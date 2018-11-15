using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public partial interface IBOLDeviceActionMapper
	{
		BODeviceAction MapModelToBO(
			int id,
			ApiDeviceActionServerRequestModel model);

		ApiDeviceActionServerResponseModel MapBOToModel(
			BODeviceAction boDeviceAction);

		List<ApiDeviceActionServerResponseModel> MapBOToModel(
			List<BODeviceAction> items);
	}
}

/*<Codenesium>
    <Hash>968a00d5c2e60ecef8392df228fcaab9</Hash>
</Codenesium>*/