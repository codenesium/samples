using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiVendorServerModelMapper
	{
		public virtual ApiVendorServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiVendorServerRequestModel request)
		{
			var response = new ApiVendorServerResponseModel();
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

		public virtual ApiVendorServerRequestModel MapServerResponseToRequest(
			ApiVendorServerResponseModel response)
		{
			var request = new ApiVendorServerRequestModel();
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

		public virtual ApiVendorClientRequestModel MapServerResponseToClientRequest(
			ApiVendorServerResponseModel response)
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

		public JsonPatchDocument<ApiVendorServerRequestModel> CreatePatch(ApiVendorServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVendorServerRequestModel>();
			patch.Replace(x => x.AccountNumber, model.AccountNumber);
			patch.Replace(x => x.ActiveFlag, model.ActiveFlag);
			patch.Replace(x => x.CreditRating, model.CreditRating);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.PreferredVendorStatu, model.PreferredVendorStatu);
			patch.Replace(x => x.PurchasingWebServiceURL, model.PurchasingWebServiceURL);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5e99ba4195d88e0a9d50e4ca1ef23743</Hash>
</Codenesium>*/