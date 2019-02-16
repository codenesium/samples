using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALStudioMapper
	{
		Studio MapModelToEntity(
			int id,
			ApiStudioServerRequestModel model);

		ApiStudioServerResponseModel MapEntityToModel(
			Studio item);

		List<ApiStudioServerResponseModel> MapEntityToModel(
			List<Studio> items);
	}
}

/*<Codenesium>
    <Hash>339c7909df3622eb8bbdd78c5e874e0f</Hash>
</Codenesium>*/