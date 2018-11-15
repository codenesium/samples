using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiCreditCardModelMapper
	{
		public virtual ApiCreditCardClientResponseModel MapClientRequestToResponse(
			int creditCardID,
			ApiCreditCardClientRequestModel request)
		{
			var response = new ApiCreditCardClientResponseModel();
			response.SetProperties(creditCardID,
			                       request.CardNumber,
			                       request.CardType,
			                       request.ExpMonth,
			                       request.ExpYear,
			                       request.ModifiedDate);
			return response;
		}

		public virtual ApiCreditCardClientRequestModel MapClientResponseToRequest(
			ApiCreditCardClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>d439ce2a22cad4b613e57642b3a556f6</Hash>
</Codenesium>*/