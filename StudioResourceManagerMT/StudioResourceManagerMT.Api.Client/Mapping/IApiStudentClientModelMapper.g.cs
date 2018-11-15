using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiStudentModelMapper
	{
		ApiStudentClientResponseModel MapClientRequestToResponse(
			int id,
			ApiStudentClientRequestModel request);

		ApiStudentClientRequestModel MapClientResponseToRequest(
			ApiStudentClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>95dceeec220e96c8941009bab7177381</Hash>
</Codenesium>*/