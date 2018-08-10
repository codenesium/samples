using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLVersionInfoMapper
	{
		BOVersionInfo MapModelToBO(
			long version,
			ApiVersionInfoRequestModel model);

		ApiVersionInfoResponseModel MapBOToModel(
			BOVersionInfo boVersionInfo);

		List<ApiVersionInfoResponseModel> MapBOToModel(
			List<BOVersionInfo> items);
	}
}

/*<Codenesium>
    <Hash>9a6ccd62a44515770d665a7f905bc071</Hash>
</Codenesium>*/