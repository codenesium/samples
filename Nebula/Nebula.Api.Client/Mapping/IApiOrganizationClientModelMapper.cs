using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiOrganizationModelMapper
	{
		ApiOrganizationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOrganizationClientRequestModel request);

		ApiOrganizationClientRequestModel MapClientResponseToRequest(
			ApiOrganizationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>00fdfae99b4b52658b0b48cef8b519fc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/