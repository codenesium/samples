using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiAddressModelMapper
	{
		ApiAddressClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAddressClientRequestModel request);

		ApiAddressClientRequestModel MapClientResponseToRequest(
			ApiAddressClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>88d318b87da1f714c87b31bcba10813d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/