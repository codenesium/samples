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
    <Hash>d9c7ed5801dd6f3bb55d9758ac60c82f</Hash>
</Codenesium>*/