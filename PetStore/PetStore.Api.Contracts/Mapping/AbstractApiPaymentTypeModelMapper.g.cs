using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public abstract class AbstractApiPaymentTypeModelMapper
	{
		public virtual ApiPaymentTypeResponseModel MapRequestToResponse(
			int id,
			ApiPaymentTypeRequestModel request)
		{
			var response = new ApiPaymentTypeResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPaymentTypeRequestModel MapResponseToRequest(
			ApiPaymentTypeResponseModel response)
		{
			var request = new ApiPaymentTypeRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPaymentTypeRequestModel> CreatePatch(ApiPaymentTypeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPaymentTypeRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3a81e19e58a5f4ba689c6d825b8c2429</Hash>
</Codenesium>*/