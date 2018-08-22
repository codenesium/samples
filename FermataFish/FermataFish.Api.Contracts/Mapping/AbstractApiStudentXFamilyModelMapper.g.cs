using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiStudentXFamilyModelMapper
	{
		public virtual ApiStudentXFamilyResponseModel MapRequestToResponse(
			int id,
			ApiStudentXFamilyRequestModel request)
		{
			var response = new ApiStudentXFamilyResponseModel();
			response.SetProperties(id,
			                       request.FamilyId,
			                       request.StudentId,
			                       request.StudioId);
			return response;
		}

		public virtual ApiStudentXFamilyRequestModel MapResponseToRequest(
			ApiStudentXFamilyResponseModel response)
		{
			var request = new ApiStudentXFamilyRequestModel();
			request.SetProperties(
				response.FamilyId,
				response.StudentId,
				response.StudioId);
			return request;
		}

		public JsonPatchDocument<ApiStudentXFamilyRequestModel> CreatePatch(ApiStudentXFamilyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStudentXFamilyRequestModel>();
			patch.Replace(x => x.FamilyId, model.FamilyId);
			patch.Replace(x => x.StudentId, model.StudentId);
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>51285779132eb4165e827d6e62207a31</Hash>
</Codenesium>*/