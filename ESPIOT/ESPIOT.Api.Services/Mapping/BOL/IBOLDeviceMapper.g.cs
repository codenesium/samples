using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public partial interface IBOLDeviceMapper
	{
		BODevice MapModelToBO(
			int id,
			ApiDeviceRequestModel model);

		ApiDeviceResponseModel MapBOToModel(
			BODevice boDevice);

		List<ApiDeviceResponseModel> MapBOToModel(
			List<BODevice> items);
	}
}

/*<Codenesium>
    <Hash>aefa3e7984d72662150fb94df1fc3d71</Hash>
</Codenesium>*/