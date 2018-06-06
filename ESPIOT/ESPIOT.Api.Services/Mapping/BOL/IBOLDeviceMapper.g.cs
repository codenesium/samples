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
			List<BODevice> items);
	}
}

/*<Codenesium>
    <Hash>e438b0f93319c48b2870b7e83968a90d</Hash>
</Codenesium>*/