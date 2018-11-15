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
			ApiErrorLogServerRequestModel model);

		ApiErrorLogServerResponseModel MapBOToModel(
			BOErrorLog boErrorLog);

		List<ApiErrorLogServerResponseModel> MapBOToModel(
			List<BOErrorLog> items);
	}
}

/*<Codenesium>
    <Hash>4021851cc0526bc0a27aaf50c84de9d4</Hash>
</Codenesium>*/