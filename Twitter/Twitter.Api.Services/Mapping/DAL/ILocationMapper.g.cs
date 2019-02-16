using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALLocationMapper
	{
		Location MapModelToEntity(
			int locationId,
			ApiLocationServerRequestModel model);

		ApiLocationServerResponseModel MapEntityToModel(
			Location item);

		List<ApiLocationServerResponseModel> MapEntityToModel(
			List<Location> items);
	}
}

/*<Codenesium>
    <Hash>7ed723c053758f9af853edc5fbff41eb</Hash>
</Codenesium>*/