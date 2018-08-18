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
			ApiDeviceActionRequestModel model);

		ApiDeviceActionResponseModel MapBOToModel(
			BODeviceAction boDeviceAction);

		List<ApiDeviceActionResponseModel> MapBOToModel(
			List<BODeviceAction> items);
	}
}

/*<Codenesium>
    <Hash>339448a9ab926769d78c43d618fb8cef</Hash>
</Codenesium>*/