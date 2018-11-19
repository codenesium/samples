using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLStudioMapper
	{
		BOStudio MapModelToBO(
			int id,
			ApiStudioServerRequestModel model);

		ApiStudioServerResponseModel MapBOToModel(
			BOStudio boStudio);

		List<ApiStudioServerResponseModel> MapBOToModel(
			List<BOStudio> items);
	}
}

/*<Codenesium>
    <Hash>cbda67ba0a2ce3186df17c6c8399bdd9</Hash>
</Codenesium>*/