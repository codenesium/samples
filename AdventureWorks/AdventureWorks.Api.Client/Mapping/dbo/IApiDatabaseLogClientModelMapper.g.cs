using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiDatabaseLogModelMapper
	{
		ApiDatabaseLogClientResponseModel MapClientRequestToResponse(
			int databaseLogID,
			ApiDatabaseLogClientRequestModel request);

		ApiDatabaseLogClientRequestModel MapClientResponseToRequest(
			ApiDatabaseLogClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>1e3e68ca40d1ee333f1625e33b3a21b0</Hash>
</Codenesium>*/