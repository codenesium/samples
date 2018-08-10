using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLErrorLogMapper
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
    <Hash>8209202fc56c5100583663e1ae881a64</Hash>
</Codenesium>*/