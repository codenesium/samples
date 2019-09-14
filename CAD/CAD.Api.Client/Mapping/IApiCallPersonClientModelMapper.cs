using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiCallPersonModelMapper
	{
		ApiCallPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallPersonClientRequestModel request);

		ApiCallPersonClientRequestModel MapClientResponseToRequest(
			ApiCallPersonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>192d11202424391ea2297c840014f275</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/