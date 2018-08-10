using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiDepartmentModelMapper
	{
		ApiDepartmentResponseModel MapRequestToResponse(
			short departmentID,
			ApiDepartmentRequestModel request);

		ApiDepartmentRequestModel MapResponseToRequest(
			ApiDepartmentResponseModel response);

		JsonPatchDocument<ApiDepartmentRequestModel> CreatePatch(ApiDepartmentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e72d6cff06365c2478f46618efc9a96b</Hash>
</Codenesium>*/