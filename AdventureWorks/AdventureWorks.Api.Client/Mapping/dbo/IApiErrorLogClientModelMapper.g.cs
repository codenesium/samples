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
    <Hash>d3eda9cd43f5b50166afa47164fd6867</Hash>
</Codenesium>*/