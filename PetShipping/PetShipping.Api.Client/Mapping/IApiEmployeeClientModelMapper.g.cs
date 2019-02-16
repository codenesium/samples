using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiEmployeeModelMapper
	{
		ApiEmployeeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEmployeeClientRequestModel request);

		ApiEmployeeClientRequestModel MapClientResponseToRequest(
			ApiEmployeeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0aaa47146796f6f783a5c5c04821e59a</Hash>
</Codenesium>*/