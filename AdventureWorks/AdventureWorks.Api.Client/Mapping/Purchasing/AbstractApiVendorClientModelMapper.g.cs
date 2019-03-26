using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiVendorModelMapper
	{
		public virtual ApiVendorClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiVendorClientRequestModel request)
		{
			var response = new ApiVendorClientResponseModel();
			response.SetProperties(businessEntityID,
			                       request.AccountNumber,
			                       request.ActiveFlag,
			                       request.CreditRating,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.PreferredVendorStatu,
			                       request.PurchasingWebServiceURL);
			return response;
		}

		public virtual ApiVendorClientRequestModel MapClientResponseToRequest(
			ApiVendorClientResponseModel response)
		{
			var request = new ApiVendorClientRequestModel();
			request.SetProperties(
				response.AccountNumber,
				response.ActiveFlag,
				response.CreditRating,
				response.ModifiedDate,
				response.Name,
				response.PreferredVendorStatu,
				response.PurchasingWebServiceURL);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>fee03bad0d059ac4f3be941fc236021d</Hash>
</Codenesium>*/