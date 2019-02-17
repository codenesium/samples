using StudioResourceManagerMTNS.Api.Contracts;
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
    <Hash>28276ba5b8342d41971e2de12486f21a</Hash>
</Codenesium>*/