using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public partial interface IApiPaymentTypeModelMapper
	{
		ApiPaymentTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPaymentTypeClientRequestModel request);

		ApiPaymentTypeClientRequestModel MapClientResponseToRequest(
			ApiPaymentTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>bc6aa9d3cc0e025406d718ccb758089c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/