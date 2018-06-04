using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Services
{
	public interface IBOLFileMapper
	{
		BOFile MapModelToBO(
			int id,
			ApiFileRequestModel model);

		ApiFileResponseModel MapBOToModel(
			BOFile boFile);

		List<ApiFileResponseModel> MapBOToModel(
			List<BOFile> bos);
	}
}

/*<Codenesium>
    <Hash>8242486aa800f3f522a004aaaa5582ce</Hash>
</Codenesium>*/