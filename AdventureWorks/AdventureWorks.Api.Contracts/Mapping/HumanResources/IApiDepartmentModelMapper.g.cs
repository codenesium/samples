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
    <Hash>05d3d03f9f7d66ee0d942df00276462e</Hash>
</Codenesium>*/