using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALEventMapper
	{
		Event MapModelToEntity(
			int id,
			ApiEventServerRequestModel model);

		ApiEventServerResponseModel MapEntityToModel(
			Event item);

		List<ApiEventServerResponseModel> MapEntityToModel(
			List<Event> items);
	}
}

/*<Codenesium>
    <Hash>79acc65d04ffa89f571f24b791e59252</Hash>
</Codenesium>*/