using Microsoft.AspNetCore.JsonPatch;
using PointOfSaleNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public class ApiCustomerServerModelMapper : IApiCustomerServerModelMapper
	{
		public virtual ApiCustomerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCustomerServerRequestModel request)
		{
			var response = new ApiCustomerServerResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone);
			return response;
		}

		public virtual ApiCustomerServerRequestModel MapServerResponseToRequest(
			ApiCustomerServerResponseModel response)
		{
			var request = new ApiCustomerServerRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone);
			return request;
		}

		public virtual ApiCustomerClientRequestModel MapServerResponseToClientRequest(
			ApiCustomerServerResponseModel response)
		{
			var request = new ApiCustomerClientRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone);
			return request;
		}

		public JsonPatchDocument<ApiCustomerServerRequestModel> CreatePatch(ApiCustomerServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCustomerServerRequestModel>();
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Phone, model.Phone);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>63717bbfa30a66bef27a07498b4c2a61</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/