using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiOfficerModelMapper
	{
		ApiOfficerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOfficerClientRequestModel request);

		ApiOfficerClientRequestModel MapClientResponseToRequest(
			ApiOfficerClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f98d24105fd851b86dba991874b5f793</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/