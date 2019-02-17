using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALErrorLogMapper
	{
		ErrorLog MapModelToEntity(
			int errorLogID,
			ApiErrorLogServerRequestModel model);

		ApiErrorLogServerResponseModel MapEntityToModel(
			ErrorLog item);

		List<ApiErrorLogServerResponseModel> MapEntityToModel(
			List<ErrorLog> items);
	}
}

/*<Codenesium>
    <Hash>ec7bfd73689c29faddda2f5f23fda931</Hash>
</Codenesium>*/