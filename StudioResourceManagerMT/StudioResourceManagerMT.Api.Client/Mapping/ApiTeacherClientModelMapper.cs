using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public class ApiTeacherModelMapper : IApiTeacherModelMapper
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
    <Hash>75562d18c4bba9cb75c14406203c0ac4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/