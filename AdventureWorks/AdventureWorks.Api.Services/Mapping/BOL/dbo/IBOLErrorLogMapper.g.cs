using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>e7b99e302950704de69f12ef60231803</Hash>
</Codenesium>*/