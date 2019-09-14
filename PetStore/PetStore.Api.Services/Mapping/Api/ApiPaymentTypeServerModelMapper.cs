using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiPaymentTypeServerModelMapper : IApiPaymentTypeServerModelMapper
	{
		public virtual ApiPaymentTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPaymentTypeServerRequestModel request)
		{
			var response = new ApiPaymentTypeServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPaymentTypeServerRequestModel MapServerResponseToRequest(
			ApiPaymentTypeServerResponseModel response)
		{
			var request = new ApiPaymentTypeServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiPaymentTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPaymentTypeServerResponseModel response)
		{
			var request = new ApiPaymentTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPaymentTypeServerRequestModel> CreatePatch(ApiPaymentTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPaymentTypeServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0ef8e7628b349d7a8cac0abb1d986178</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/