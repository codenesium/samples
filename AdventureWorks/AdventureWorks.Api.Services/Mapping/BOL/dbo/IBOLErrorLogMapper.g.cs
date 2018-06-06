using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLErrorLogMapper
	{
		BOErrorLog MapModelToBO(
			int errorLogID,
			ApiErrorLogRequestModel model);

		ApiErrorLogResponseModel MapBOToModel(
			BOErrorLog boErrorLog);

		List<ApiErrorLogResponseModel> MapBOToModel(
			List<BOErrorLog> items);
	}
}

/*<Codenesium>
    <Hash>16d6f4a10b36c943b3555a1a4950eb62</Hash>
</Codenesium>*/