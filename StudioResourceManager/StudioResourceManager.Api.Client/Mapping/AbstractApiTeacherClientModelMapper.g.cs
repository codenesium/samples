using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiTeacherModelMapper
	{
		public virtual ApiTeacherClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTeacherClientRequestModel request)
		{
			var response = new ApiTeacherClientResponseModel();
			response.SetProperties(id,
			                       request.Birthday,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone,
			                       request.UserId);
			return response;
		}

		public virtual ApiTeacherClientRequestModel MapClientResponseToRequest(
			ApiTeacherClientResponseModel response)
		{
			var request = new ApiTeacherClientRequestModel();
			request.SetProperties(
				response.Birthday,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone,
				response.UserId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5ed140e7bac019e99524bf48f44995de</Hash>
</Codenesium>*/