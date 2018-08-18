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
    <Hash>9032c53e4203d03fd05264d9990110e8</Hash>
</Codenesium>*/