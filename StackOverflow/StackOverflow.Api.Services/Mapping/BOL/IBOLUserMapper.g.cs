using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
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
    <Hash>36cd2323546f74c5dc320139eecdd01d</Hash>
</Codenesium>*/