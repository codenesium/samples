using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>32117dcf9b43244784b7b7f38fbe9c8a</Hash>
</Codenesium>*/