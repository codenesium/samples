using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public interface IBOLDeviceMapper
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
    <Hash>b7f180a2bac9df763393a8c5e98a2436</Hash>
</Codenesium>*/