using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>c5aaa659cbbd6caf900812abebae2f10</Hash>
</Codenesium>*/