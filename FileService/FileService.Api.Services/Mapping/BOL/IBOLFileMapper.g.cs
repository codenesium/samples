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
			ApiFileServerRequestModel model);

		ApiFileServerResponseModel MapBOToModel(
			BOFile boFile);

		List<ApiFileServerResponseModel> MapBOToModel(
			List<BOFile> items);
	}
}

/*<Codenesium>
    <Hash>c9e3f7e39a54cf02d27e25ee144777a7</Hash>
</Codenesium>*/