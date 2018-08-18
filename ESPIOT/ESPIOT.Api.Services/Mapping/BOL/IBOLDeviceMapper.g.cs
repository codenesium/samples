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
    <Hash>5d60024feb9a857eb0a38f228b0b6303</Hash>
</Codenesium>*/