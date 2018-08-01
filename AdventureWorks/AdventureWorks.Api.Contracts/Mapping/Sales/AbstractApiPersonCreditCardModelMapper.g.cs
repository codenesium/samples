using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiPersonCreditCardModelMapper
	{
		public virtual ApiPersonCreditCardResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPersonCreditCardRequestModel request)
		{
			var response = new ApiPersonCreditCardResponseModel();
			response.SetProperties(businessEntityID,
			                       request.CreditCardID,
			                       request.ModifiedDate);
			return response;
		}

		public virtual ApiPersonCreditCardRequestModel MapResponseToRequest(
			ApiPersonCreditCardResponseModel response)
		{
			var request = new ApiPersonCreditCardRequestModel();
			request.SetProperties(
				response.CreditCardID,
				response.ModifiedDate);
			return request;
		}

		public JsonPatchDocument<ApiPersonCreditCardRequestModel> CreatePatch(ApiPersonCreditCardRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPersonCreditCardRequestModel>();
			patch.Replace(x => x.CreditCardID, model.CreditCardID);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d4884d78e7c2adf7fde2cb2f419b2995</Hash>
</Codenesium>*/