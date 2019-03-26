using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiErrorLogModelMapper
	{
		ApiErrorLogClientResponseModel MapClientRequestToResponse(
			int errorLogID,
			ApiErrorLogClientRequestModel request);

		ApiErrorLogClientRequestModel MapClientResponseToRequest(
			ApiErrorLogClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0cf9cad2c8c8eb95ae27505d211a7235</Hash>
</Codenesium>*/