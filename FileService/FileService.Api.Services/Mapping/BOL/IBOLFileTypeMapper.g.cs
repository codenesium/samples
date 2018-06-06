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
			List<BOFileType> items);
	}
}

/*<Codenesium>
    <Hash>4d7a60457e889e20240a830fe28aec94</Hash>
</Codenesium>*/