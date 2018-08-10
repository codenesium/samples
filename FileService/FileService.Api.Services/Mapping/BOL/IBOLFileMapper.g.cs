using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IBOLFileMapper
	{
		BOFile MapModelToBO(
			int id,
			ApiFileRequestModel model);

		ApiFileResponseModel MapBOToModel(
			BOFile boFile);

		List<ApiFileResponseModel> MapBOToModel(
			List<BOFile> items);
	}
}

/*<Codenesium>
    <Hash>15b902149624e3aa7d32b97808382ef6</Hash>
</Codenesium>*/