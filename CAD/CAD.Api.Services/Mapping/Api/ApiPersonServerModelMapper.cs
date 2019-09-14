using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiPersonServerModelMapper : IApiPersonServerModelMapper
	{
		public virtual ApiPersonServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPersonServerRequestModel request)
		{
			var response = new ApiPersonServerResponseModel();
			response.SetProperties(id,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone,
			                       request.Ssn);
			return response;
		}

		public virtual ApiPersonServerRequestModel MapServerResponseToRequest(
			ApiPersonServerResponseModel response)
		{
			var request = new ApiPersonServerRequestModel();
			request.SetProperties(
				response.FirstName,
				response.LastName,
				response.Phone,
				response.Ssn);
			return request;
		}

		public virtual ApiPersonClientRequestModel MapServerResponseToClientRequest(
			ApiPersonServerResponseModel response)
		{
			var request = new ApiPersonClientRequestModel();
			request.SetProperties(
				response.FirstName,
				response.LastName,
				response.Phone,
				response.Ssn);
			return request;
		}

		public JsonPatchDocument<ApiPersonServerRequestModel> CreatePatch(ApiPersonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPersonServerRequestModel>();
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Phone, model.Phone);
			patch.Replace(x => x.Ssn, model.Ssn);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>559cac4c8fac60904f9389691070fcab</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/