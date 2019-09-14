using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public class ApiStudentModelMapper : IApiStudentModelMapper
	{
		public virtual ApiStudentClientResponseModel MapClientRequestToResponse(
			int id,
			ApiStudentClientRequestModel request)
		{
			var response = new ApiStudentClientResponseModel();
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

		public virtual ApiStudentClientRequestModel MapClientResponseToRequest(
			ApiStudentClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>54c3a6919ad70ca76fa965e5e4ef11c8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/