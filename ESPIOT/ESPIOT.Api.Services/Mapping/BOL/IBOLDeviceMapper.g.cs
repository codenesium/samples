using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
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
			List<BODevice> bos);
	}
}

/*<Codenesium>
    <Hash>48c9a8218c2650d579e9e51baec2c71c</Hash>
</Codenesium>*/