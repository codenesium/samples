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
    <Hash>9b1f87c64a3280b3c498f531723656ed</Hash>
</Codenesium>*/