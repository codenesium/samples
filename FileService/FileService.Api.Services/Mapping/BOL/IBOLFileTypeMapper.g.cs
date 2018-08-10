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
			ApiFileTypeRequestModel model);

		ApiFileTypeResponseModel MapBOToModel(
			BOFileType boFileType);

		List<ApiFileTypeResponseModel> MapBOToModel(
			List<BOFileType> items);
	}
}

/*<Codenesium>
    <Hash>3a14b5864ba7c0d8325bd30a5f8ab679</Hash>
</Codenesium>*/