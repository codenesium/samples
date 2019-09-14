using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOfficerServerModelMapper : IApiOfficerServerModelMapper
	{
		public virtual ApiOfficerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOfficerServerRequestModel request)
		{
			var response = new ApiOfficerServerResponseModel();
			response.SetProperties(id,
			                       request.Badge,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Password);
			return response;
		}

		public virtual ApiOfficerServerRequestModel MapServerResponseToRequest(
			ApiOfficerServerResponseModel response)
		{
			var request = new ApiOfficerServerRequestModel();
			request.SetProperties(
				response.Badge,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Password);
			return request;
		}

		public virtual ApiOfficerClientRequestModel MapServerResponseToClientRequest(
			ApiOfficerServerResponseModel response)
		{
			var request = new ApiOfficerClientRequestModel();
			request.SetProperties(
				response.Badge,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Password);
			return request;
		}

		public JsonPatchDocument<ApiOfficerServerRequestModel> CreatePatch(ApiOfficerServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOfficerServerRequestModel>();
			patch.Replace(x => x.Badge, model.Badge);
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Password, model.Password);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4e541888bb59ef7e77689bca93b7c216</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/