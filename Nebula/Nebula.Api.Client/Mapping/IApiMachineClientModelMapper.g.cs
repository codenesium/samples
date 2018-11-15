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
    <Hash>4491abcdd204eea9cc1d7c6d1d6c5617</Hash>
</Codenesium>*/