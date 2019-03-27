using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALVersionInfoMapper
	{
		VersionInfo MapModelToEntity(
			long version,
			ApiVersionInfoServerRequestModel model);

		ApiVersionInfoServerResponseModel MapEntityToModel(
			VersionInfo item);

		List<ApiVersionInfoServerResponseModel> MapEntityToModel(
			List<VersionInfo> items);
	}
}

/*<Codenesium>
    <Hash>74b055b698860cfa3e766b385138bc64</Hash>
</Codenesium>*/