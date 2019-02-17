using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALUserMapper
	{
		User MapModelToEntity(
			int id,
			ApiUserServerRequestModel model);

		ApiUserServerResponseModel MapEntityToModel(
			User item);

		List<ApiUserServerResponseModel> MapEntityToModel(
			List<User> items);
	}
}

/*<Codenesium>
    <Hash>558599f34f02f04e5a2660aec945bdc7</Hash>
</Codenesium>*/