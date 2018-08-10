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
    <Hash>cafee795094b2d70b86778cdf16be339</Hash>
</Codenesium>*/