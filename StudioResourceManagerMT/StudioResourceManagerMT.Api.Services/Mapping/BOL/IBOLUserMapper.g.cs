using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLUserMapper
	{
		BOUser MapModelToBO(
			int id,
			ApiUserServerRequestModel model);

		ApiUserServerResponseModel MapBOToModel(
			BOUser boUser);

		List<ApiUserServerResponseModel> MapBOToModel(
			List<BOUser> items);
	}
}

/*<Codenesium>
    <Hash>6417bfa0d720a227a505400146db963c</Hash>
</Codenesium>*/