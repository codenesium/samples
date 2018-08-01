using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
	public interface IBOLFileTypeMapper
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
    <Hash>fdbee1bcc64e93e42f7d2bb38d2648bd</Hash>
</Codenesium>*/