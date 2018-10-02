using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLUserMapper
	{
		BOUser MapModelToBO(
			int userId,
			ApiUserRequestModel model);

		ApiUserResponseModel MapBOToModel(
			BOUser boUser);

		List<ApiUserResponseModel> MapBOToModel(
			List<BOUser> items);
	}
}

/*<Codenesium>
    <Hash>f06263006c5de9b4c3dedb8bbd3c6587</Hash>
</Codenesium>*/