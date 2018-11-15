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
			ApiDeviceServerRequestModel model);

		ApiDeviceServerResponseModel MapBOToModel(
			BODevice boDevice);

		List<ApiDeviceServerResponseModel> MapBOToModel(
			List<BODevice> items);
	}
}

/*<Codenesium>
    <Hash>26cbcd2ed02dd07b698dad9dcedd04a9</Hash>
</Codenesium>*/