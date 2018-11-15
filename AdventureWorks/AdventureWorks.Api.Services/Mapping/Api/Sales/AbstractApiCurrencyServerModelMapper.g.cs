using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCurrencyServerModelMapper
	{
		public virtual ApiCurrencyServerResponseModel MapServerRequestToResponse(
			string currencyCode,
			ApiCurrencyServerRequestModel request)
		{
			var response = new ApiCurrencyServerResponseModel();
			response.SetProperties(currencyCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCurrencyServerRequestModel MapServerResponseToRequest(
			ApiCurrencyServerResponseModel response)
		{
			var request = new ApiCurrencyServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public virtual ApiCurrencyClientRequestModel MapServerResponseToClientRequest(
			ApiCurrencyServerResponseModel response)
		{
			var request = new ApiCurrencyClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCurrencyServerRequestModel> CreatePatch(ApiCurrencyServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCurrencyServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>64c2d9d83142cdb3a158fa3443377ece</Hash>
</Codenesium>*/