using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALCallTypeMapper
	{
		CallType MapModelToEntity(
			int id,
			ApiCallTypeServerRequestModel model);

		ApiCallTypeServerResponseModel MapEntityToModel(
			CallType item);

		List<ApiCallTypeServerResponseModel> MapEntityToModel(
			List<CallType> items);
	}
}

/*<Codenesium>
    <Hash>099cfdbe8ebe1e693301ff58e2133989</Hash>
</Codenesium>*/