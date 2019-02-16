using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Client
{
	public partial interface IApiTestAllFieldTypeModelMapper
	{
		ApiTestAllFieldTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTestAllFieldTypeClientRequestModel request);

		ApiTestAllFieldTypeClientRequestModel MapClientResponseToRequest(
			ApiTestAllFieldTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>07382e713afc8fef5bcef1b206e0c0de</Hash>
</Codenesium>*/