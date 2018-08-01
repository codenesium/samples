using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLUsersMapper
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
    <Hash>ee33589e7bad5db6e2543bdd6ed7a285</Hash>
</Codenesium>*/