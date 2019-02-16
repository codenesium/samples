using AdventureWorksNS.Api.Contracts;
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
    <Hash>5294c6ed190dbff289535c05ca547a06</Hash>
</Codenesium>*/