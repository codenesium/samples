using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiStudentServerModelMapper : IApiStudentServerModelMapper
	{
		public virtual ApiStudentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiStudentServerRequestModel request)
		{
			var response = new ApiStudentServerResponseModel();
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

		public virtual ApiStudentServerRequestModel MapServerResponseToRequest(
			ApiStudentServerResponseModel response)
		{
			var request = new ApiStudentServerRequestModel();
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

		public virtual ApiStudentClientRequestModel MapServerResponseToClientRequest(
			ApiStudentServerResponseModel response)
		{
			var request = new ApiStudentClientRequestModel();
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

		public JsonPatchDocument<ApiStudentServerRequestModel> CreatePatch(ApiStudentServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStudentServerRequestModel>();
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
    <Hash>d3f9c39a4917c13a97145fdd2e6df6cd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/