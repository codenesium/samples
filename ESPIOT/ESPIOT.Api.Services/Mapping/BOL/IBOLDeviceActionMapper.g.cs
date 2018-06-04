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
			List<BODeviceAction> bos);
	}
}

/*<Codenesium>
    <Hash>b9b7749dc6cbfa5d2be9d66c2235ab67</Hash>
</Codenesium>*/