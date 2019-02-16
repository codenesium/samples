using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALErrorLogMapper
	{
		ErrorLog MapModelToBO(
			int errorLogID,
			ApiErrorLogServerRequestModel model);

		ApiErrorLogServerResponseModel MapBOToModel(
			ErrorLog item);

		List<ApiErrorLogServerResponseModel> MapBOToModel(
			List<ErrorLog> items);
	}
}

/*<Codenesium>
    <Hash>46b9081d0d8db17864892c0c63490986</Hash>
</Codenesium>*/