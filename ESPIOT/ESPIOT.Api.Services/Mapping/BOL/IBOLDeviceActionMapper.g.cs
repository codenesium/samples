using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
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
    <Hash>3ca0925ee2fc5e6a0a8bb651453e644b</Hash>
</Codenesium>*/