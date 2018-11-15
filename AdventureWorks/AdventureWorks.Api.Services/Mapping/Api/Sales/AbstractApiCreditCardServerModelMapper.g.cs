using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCreditCardServerModelMapper
	{
		public virtual ApiCreditCardServerResponseModel MapServerRequestToResponse(
			int creditCardID,
			ApiCreditCardServerRequestModel request)
		{
			var response = new ApiCreditCardServerResponseModel();
			response.SetProperties(creditCardID,
			                       request.CardNumber,
			                       request.CardType,
			                       request.ExpMonth,
			                       request.ExpYear,
			                       request.ModifiedDate);
			return response;
		}

		public virtual ApiCreditCardServerRequestModel MapServerResponseToRequest(
			ApiCreditCardServerResponseModel response)
		{
			var request = new ApiCreditCardServerRequestModel();
			request.SetProperties(
				response.CardNumber,
				response.CardType,
				response.ExpMonth,
				response.ExpYear,
				response.ModifiedDate);
			return request;
		}

		public virtual ApiCreditCardClientRequestModel MapServerResponseToClientRequest(
			ApiCreditCardServerResponseModel response)
		{
			var request = new ApiCreditCardClientRequestModel();
			request.SetProperties(
				response.CardNumber,
				response.CardType,
				response.ExpMonth,
				response.ExpYear,
				response.ModifiedDate);
			return request;
		}

		public JsonPatchDocument<ApiCreditCardServerRequestModel> CreatePatch(ApiCreditCardServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCreditCardServerRequestModel>();
			patch.Replace(x => x.CardNumber, model.CardNumber);
			patch.Replace(x => x.CardType, model.CardType);
			patch.Replace(x => x.ExpMonth, model.ExpMonth);
			patch.Replace(x => x.ExpYear, model.ExpYear);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f38e5230dced4a3d3cba993fb232634d</Hash>
</Codenesium>*/