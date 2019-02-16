using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiMachineModelMapper
	{
		ApiMachineClientResponseModel MapClientRequestToResponse(
			int id,
			ApiMachineClientRequestModel request);

		ApiMachineClientRequestModel MapClientResponseToRequest(
			ApiMachineClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7be85a53bca1487da8224f27ebc815d4</Hash>
</Codenesium>*/