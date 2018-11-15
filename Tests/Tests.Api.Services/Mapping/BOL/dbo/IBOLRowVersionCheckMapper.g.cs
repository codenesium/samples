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
			ApiRowVersionCheckServerRequestModel model);

		ApiRowVersionCheckServerResponseModel MapBOToModel(
			BORowVersionCheck boRowVersionCheck);

		List<ApiRowVersionCheckServerResponseModel> MapBOToModel(
			List<BORowVersionCheck> items);
	}
}

/*<Codenesium>
    <Hash>9dce4a7ef9883c6fbaf2c313c8eb9a9a</Hash>
</Codenesium>*/