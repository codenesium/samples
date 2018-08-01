using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiCurrencyModelMapper
	{
		public virtual ApiCurrencyResponseModel MapRequestToResponse(
			string currencyCode,
			ApiCurrencyRequestModel request)
		{
			var response = new ApiCurrencyResponseModel();
			response.SetProperties(currencyCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCurrencyRequestModel MapResponseToRequest(
			ApiCurrencyResponseModel response)
		{
			var request = new ApiCurrencyRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCurrencyRequestModel> CreatePatch(ApiCurrencyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCurrencyRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>64828d7c779d5a0200bad83e4d74613e</Hash>
</Codenesium>*/