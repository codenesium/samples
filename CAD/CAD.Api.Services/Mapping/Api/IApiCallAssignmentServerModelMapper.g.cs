using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallAssignmentServerModelMapper
	{
		ApiCallAssignmentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallAssignmentServerRequestModel request);

		ApiCallAssignmentServerRequestModel MapServerResponseToRequest(
			ApiCallAssignmentServerResponseModel response);

		ApiCallAssignmentClientRequestModel MapServerResponseToClientRequest(
			ApiCallAssignmentServerResponseModel response);

		JsonPatchDocument<ApiCallAssignmentServerRequestModel> CreatePatch(ApiCallAssignmentServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4cd39fc7cc61b120370b24b627e0d8d2</Hash>
</Codenesium>*/