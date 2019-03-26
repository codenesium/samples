using AdventureWorksNS.Api.Contracts;
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
    <Hash>0e0eddd5e939ac9a5bb378eaa80c7071</Hash>
</Codenesium>*/