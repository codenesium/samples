using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public partial interface IBOLFileTypeMapper
	{
		BOFileType MapModelToBO(
			int id,
			ApiFileTypeServerRequestModel model);

		ApiFileTypeServerResponseModel MapBOToModel(
			BOFileType boFileType);

		List<ApiFileTypeServerResponseModel> MapBOToModel(
			List<BOFileType> items);
	}
}

/*<Codenesium>
    <Hash>dd630d375f7486d6c965e52a676fb5d8</Hash>
</Codenesium>*/