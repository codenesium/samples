using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiEventStudentModelMapper
	{
		ApiEventStudentClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventStudentClientRequestModel request);

		ApiEventStudentClientRequestModel MapClientResponseToRequest(
			ApiEventStudentClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f5080b1b30e866ca909c3f17da7e113a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/