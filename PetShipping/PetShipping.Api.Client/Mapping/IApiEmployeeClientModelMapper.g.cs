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
    <Hash>f27906a94f36a8ae48792a1ab87eaf67</Hash>
</Codenesium>*/