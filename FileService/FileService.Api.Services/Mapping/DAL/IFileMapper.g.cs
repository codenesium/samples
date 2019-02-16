using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IDALFileMapper
	{
		File MapModelToEntity(
			int id,
			ApiFileServerRequestModel model);

		ApiFileServerResponseModel MapEntityToModel(
			File item);

		List<ApiFileServerResponseModel> MapEntityToModel(
			List<File> items);
	}
}

/*<Codenesium>
    <Hash>f6121e03f7d9b5a1c79de684663484e9</Hash>
</Codenesium>*/