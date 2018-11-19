using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLEventMapper
	{
		BOEvent MapModelToBO(
			int id,
			ApiEventServerRequestModel model);

		ApiEventServerResponseModel MapBOToModel(
			BOEvent boEvent);

		List<ApiEventServerResponseModel> MapBOToModel(
			List<BOEvent> items);
	}
}

/*<Codenesium>
    <Hash>854e5e2d9a667ec05d89d34132496cdc</Hash>
</Codenesium>*/