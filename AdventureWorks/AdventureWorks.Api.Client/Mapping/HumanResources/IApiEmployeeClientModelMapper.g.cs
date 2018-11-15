using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiEmployeeModelMapper
	{
		ApiEmployeeClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiEmployeeClientRequestModel request);

		ApiEmployeeClientRequestModel MapClientResponseToRequest(
			ApiEmployeeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2d6d6fa38085ecf22ff6a98a2df9248c</Hash>
</Codenesium>*/