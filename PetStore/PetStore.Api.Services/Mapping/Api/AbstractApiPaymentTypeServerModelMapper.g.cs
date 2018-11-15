using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPaymentTypeServerModelMapper
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
    <Hash>e075bd559754ad308b563d9152fab9d8</Hash>
</Codenesium>*/