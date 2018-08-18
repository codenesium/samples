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
    <Hash>b17694e3a89c320c79df2d2d428760ee</Hash>
</Codenesium>*/