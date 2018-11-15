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
    <Hash>3724686274b1ce55d1a9ac6a35cc49ac</Hash>
</Codenesium>*/