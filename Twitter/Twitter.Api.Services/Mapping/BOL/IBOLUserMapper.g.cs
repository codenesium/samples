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
			ApiUserServerRequestModel model);

		ApiUserServerResponseModel MapBOToModel(
			BOUser boUser);

		List<ApiUserServerResponseModel> MapBOToModel(
			List<BOUser> items);
	}
}

/*<Codenesium>
    <Hash>85b02328160aa8e1292f237150e7b44b</Hash>
</Codenesium>*/