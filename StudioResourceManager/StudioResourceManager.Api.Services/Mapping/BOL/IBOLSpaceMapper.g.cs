using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLSpaceMapper
	{
		BOSpace MapModelToBO(
			int id,
			ApiSpaceRequestModel model);

		ApiSpaceResponseModel MapBOToModel(
			BOSpace boSpace);

		List<ApiSpaceResponseModel> MapBOToModel(
			List<BOSpace> items);
	}
}

/*<Codenesium>
    <Hash>b1711a92631767f6ad99c106884a3c00</Hash>
</Codenesium>*/