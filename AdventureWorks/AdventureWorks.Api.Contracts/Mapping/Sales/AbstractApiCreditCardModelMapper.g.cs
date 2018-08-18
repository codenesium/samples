using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiCreditCardModelMapper
	{
		public virtual ApiCreditCardResponseModel MapRequestToResponse(
			int creditCardID,
			ApiCreditCardRequestModel request)
		{
			var response = new ApiCreditCardResponseModel();
			response.SetProperties(creditCardID,
			                       request.CardNumber,
			                       request.CardType,
			                       request.ExpMonth,
			                       request.ExpYear,
			                       request.ModifiedDate);
			return response;
		}

		public virtual ApiCreditCardRequestModel MapResponseToRequest(
			ApiCreditCardResponseModel response)
		{
			var request = new ApiCreditCardRequestModel();
			request.SetProperties(
				response.CardNumber,
				response.CardType,
				response.ExpMonth,
				response.ExpYear,
				response.ModifiedDate);
			return request;
		}

		public JsonPatchDocument<ApiCreditCardRequestModel> CreatePatch(ApiCreditCardRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCreditCardRequestModel>();
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
    <Hash>dbdd6a0cf3de36f697c4d185c13b266f</Hash>
</Codenesium>*/