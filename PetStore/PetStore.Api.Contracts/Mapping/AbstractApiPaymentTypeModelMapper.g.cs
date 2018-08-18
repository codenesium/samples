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
    <Hash>7cbf32dd79cbd06b9ee1c4cd56f96a6a</Hash>
</Codenesium>*/