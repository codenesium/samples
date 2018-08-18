using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLUsersMapper
	{
		BOUsers MapModelToBO(
			int id,
			ApiUsersRequestModel model);

		ApiUsersResponseModel MapBOToModel(
			BOUsers boUsers);

		List<ApiUsersResponseModel> MapBOToModel(
			List<BOUsers> items);
	}
}

/*<Codenesium>
    <Hash>10b77d85d279454c1771d59ed1a8c094</Hash>
</Codenesium>*/