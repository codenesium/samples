using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiCustomerServerModelMapper
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
			                       request.Note,
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
				response.Note,
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
				response.Note,
				response.Phone);
			return request;
		}

		public JsonPatchDocument<ApiCustomerServerRequestModel> CreatePatch(ApiCustomerServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCustomerServerRequestModel>();
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Note, model.Note);
			patch.Replace(x => x.Phone, model.Phone);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>fda77791da9accdd8a05ae9afb3f8371</Hash>
</Codenesium>*/