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
			List<BOFile> items);
	}
}

/*<Codenesium>
    <Hash>dcc8cea32769a7f8b98d86bfb787ba79</Hash>
</Codenesium>*/