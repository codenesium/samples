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
			ApiVersionInfoServerRequestModel model);

		ApiVersionInfoServerResponseModel MapBOToModel(
			BOVersionInfo boVersionInfo);

		List<ApiVersionInfoServerResponseModel> MapBOToModel(
			List<BOVersionInfo> items);
	}
}

/*<Codenesium>
    <Hash>7cb82c38ab61d142ef5a2fef0adf8c4b</Hash>
</Codenesium>*/