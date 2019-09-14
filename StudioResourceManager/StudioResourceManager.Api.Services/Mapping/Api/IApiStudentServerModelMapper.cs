using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiStudentServerModelMapper
	{
		ApiStudentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiStudentServerRequestModel request);

		ApiStudentServerRequestModel MapServerResponseToRequest(
			ApiStudentServerResponseModel response);

		ApiStudentClientRequestModel MapServerResponseToClientRequest(
			ApiStudentServerResponseModel response);

		JsonPatchDocument<ApiStudentServerRequestModel> CreatePatch(ApiStudentServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>77f768f92ba022b56b350bdd57029392</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/