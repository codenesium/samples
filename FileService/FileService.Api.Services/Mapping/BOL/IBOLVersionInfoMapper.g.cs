using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
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
    <Hash>8b57e9da8f9af2aabb2c1b68e7cc4751</Hash>
</Codenesium>*/