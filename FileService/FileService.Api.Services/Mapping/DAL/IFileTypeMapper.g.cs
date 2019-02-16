using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IDALFileTypeMapper
	{
		FileType MapModelToEntity(
			int id,
			ApiFileTypeServerRequestModel model);

		ApiFileTypeServerResponseModel MapEntityToModel(
			FileType item);

		List<ApiFileTypeServerResponseModel> MapEntityToModel(
			List<FileType> items);
	}
}

/*<Codenesium>
    <Hash>72199f43dbde6669827a627d5869e99d</Hash>
</Codenesium>*/