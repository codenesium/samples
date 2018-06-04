using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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
			List<BOFileType> bos);
	}
}

/*<Codenesium>
    <Hash>9337850c86b051c58690caa99d1d3387</Hash>
</Codenesium>*/