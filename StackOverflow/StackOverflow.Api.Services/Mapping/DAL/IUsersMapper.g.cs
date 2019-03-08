using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALUsersMapper
	{
		Users MapModelToEntity(
			int id,
			ApiUsersServerRequestModel model);

		ApiUsersServerResponseModel MapEntityToModel(
			Users item);

		List<ApiUsersServerResponseModel> MapEntityToModel(
			List<Users> items);
	}
}

/*<Codenesium>
    <Hash>364e737fb3e89473b7154dc1bf194902</Hash>
</Codenesium>*/