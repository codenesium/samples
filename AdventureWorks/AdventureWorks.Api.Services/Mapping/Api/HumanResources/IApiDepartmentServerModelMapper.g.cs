using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiDepartmentServerModelMapper
	{
		ApiDepartmentServerResponseModel MapServerRequestToResponse(
			short departmentID,
			ApiDepartmentServerRequestModel request);

		ApiDepartmentServerRequestModel MapServerResponseToRequest(
			ApiDepartmentServerResponseModel response);

		ApiDepartmentClientRequestModel MapServerResponseToClientRequest(
			ApiDepartmentServerResponseModel response);

		JsonPatchDocument<ApiDepartmentServerRequestModel> CreatePatch(ApiDepartmentServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0941c57e2364982313af55595f57f80b</Hash>
</Codenesium>*/