using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a111c14463a8ce07b6d0b55139f80dcb</Hash>
</Codenesium>*/