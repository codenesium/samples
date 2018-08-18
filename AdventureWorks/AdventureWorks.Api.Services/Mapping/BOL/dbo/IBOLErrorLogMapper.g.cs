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
    <Hash>d9f5ec02a88369a8a0d0759ffdb5380f</Hash>
</Codenesium>*/