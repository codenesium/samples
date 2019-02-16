using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
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
    <Hash>f30f3edc1d2510ae1ff45f7fd56861e7</Hash>
</Codenesium>*/