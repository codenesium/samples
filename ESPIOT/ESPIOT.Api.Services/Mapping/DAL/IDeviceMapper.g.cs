using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public partial interface IDALDeviceMapper
	{
		Device MapModelToEntity(
			int id,
			ApiDeviceServerRequestModel model);

		ApiDeviceServerResponseModel MapEntityToModel(
			Device item);

		List<ApiDeviceServerResponseModel> MapEntityToModel(
			List<Device> items);
	}
}

/*<Codenesium>
    <Hash>611b7b7b1d68e55bb62dcb34da703708</Hash>
</Codenesium>*/