using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public partial interface IApiStudentXFamilyModelMapper
	{
		ApiStudentXFamilyResponseModel MapRequestToResponse(
			int id,
			ApiStudentXFamilyRequestModel request);

		ApiStudentXFamilyRequestModel MapResponseToRequest(
			ApiStudentXFamilyResponseModel response);

		JsonPatchDocument<ApiStudentXFamilyRequestModel> CreatePatch(ApiStudentXFamilyRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b0e0c6d9adf107427c3968271044c5ac</Hash>
</Codenesium>*/