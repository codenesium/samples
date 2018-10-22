using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiStudentModelMapper
	{
		public virtual ApiStudentResponseModel MapRequestToResponse(
			int id,
			ApiStudentRequestModel request)
		{
			var response = new ApiStudentResponseModel();
			response.SetProperties(id,
			                       request.Birthday,
			                       request.Email,
			                       request.EmailRemindersEnabled,
			                       request.FamilyId,
			                       request.FirstName,
			                       request.IsAdult,
			                       request.LastName,
			                       request.Phone,
			                       request.SmsRemindersEnabled,
			                       request.UserId);
			return response;
		}

		public virtual ApiStudentRequestModel MapResponseToRequest(
			ApiStudentResponseModel response)
		{
			var request = new ApiStudentRequestModel();
			request.SetProperties(
				response.Birthday,
				response.Email,
				response.EmailRemindersEnabled,
				response.FamilyId,
				response.FirstName,
				response.IsAdult,
				response.LastName,
				response.Phone,
				response.SmsRemindersEnabled,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiStudentRequestModel> CreatePatch(ApiStudentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStudentRequestModel>();
			patch.Replace(x => x.Birthday, model.Birthday);
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.EmailRemindersEnabled, model.EmailRemindersEnabled);
			patch.Replace(x => x.FamilyId, model.FamilyId);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.IsAdult, model.IsAdult);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Phone, model.Phone);
			patch.Replace(x => x.SmsRemindersEnabled, model.SmsRemindersEnabled);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a36798a5ed77c7c73ea28602bdbb339c</Hash>
</Codenesium>*/