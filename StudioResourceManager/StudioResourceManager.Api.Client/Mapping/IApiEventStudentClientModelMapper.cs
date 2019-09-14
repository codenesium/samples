using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>dbbb118f87372ea82e6c880ab2a501d6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/