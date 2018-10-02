using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLUserMapper
	{
		BOUser MapModelToBO(
			int id,
			ApiUserRequestModel model);

		ApiUserResponseModel MapBOToModel(
			BOUser boUser);

		List<ApiUserResponseModel> MapBOToModel(
			List<BOUser> items);
	}
}

/*<Codenesium>
    <Hash>7c32d92b4fcede4ca40c8525e8e8d574</Hash>
</Codenesium>*/