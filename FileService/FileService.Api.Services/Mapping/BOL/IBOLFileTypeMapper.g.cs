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
    <Hash>3b19ff1996294438fa819a209385bb85</Hash>
</Codenesium>*/