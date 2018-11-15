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
			ApiUserServerRequestModel model);

		ApiUserServerResponseModel MapBOToModel(
			BOUser boUser);

		List<ApiUserServerResponseModel> MapBOToModel(
			List<BOUser> items);
	}
}

/*<Codenesium>
    <Hash>61e297e15dc662ab14d84c874283aa4e</Hash>
</Codenesium>*/