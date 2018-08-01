using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiDepartmentModelMapper
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
    <Hash>4a11f053ef61a5052c8df50032ba591b</Hash>
</Codenesium>*/