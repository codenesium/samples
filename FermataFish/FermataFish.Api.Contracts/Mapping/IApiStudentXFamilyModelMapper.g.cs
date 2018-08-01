using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiStudentXFamilyModelMapper
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
    <Hash>31914b08204b348c47394e56bb6a49dd</Hash>
</Codenesium>*/