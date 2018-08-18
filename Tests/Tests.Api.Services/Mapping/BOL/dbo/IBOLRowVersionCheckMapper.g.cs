using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLRowVersionCheckMapper
	{
		BORowVersionCheck MapModelToBO(
			int id,
			ApiRowVersionCheckRequestModel model);

		ApiRowVersionCheckResponseModel MapBOToModel(
			BORowVersionCheck boRowVersionCheck);

		List<ApiRowVersionCheckResponseModel> MapBOToModel(
			List<BORowVersionCheck> items);
	}
}

/*<Codenesium>
    <Hash>3277d649e1895422b408dab7c3df7e66</Hash>
</Codenesium>*/