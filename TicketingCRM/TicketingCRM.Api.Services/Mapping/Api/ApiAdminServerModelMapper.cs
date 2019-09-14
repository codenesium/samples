using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public class ApiAdminServerModelMapper : IApiAdminServerModelMapper
	{
		public virtual ApiAdminServerResponseModel MapServerRequestToResponse(
			int id,
			ApiAdminServerRequestModel request)
		{
			var response = new ApiAdminServerResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Password,
			                       request.Phone,
			                       request.Username);
			return response;
		}

		public virtual ApiAdminServerRequestModel MapServerResponseToRequest(
			ApiAdminServerResponseModel response)
		{
			var request = new ApiAdminServerRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Password,
				response.Phone,
				response.Username);
			return request;
		}

		public virtual ApiAdminClientRequestModel MapServerResponseToClientRequest(
			ApiAdminServerResponseModel response)
		{
			var request = new ApiAdminClientRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Password,
				response.Phone,
				response.Username);
			return request;
		}

		public JsonPatchDocument<ApiAdminServerRequestModel> CreatePatch(ApiAdminServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAdminServerRequestModel>();
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Password, model.Password);
			patch.Replace(x => x.Phone, model.Phone);
			patch.Replace(x => x.Username, model.Username);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>895a5423e53aa7b2d0338a4f228ff07b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/