using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiCustomerModelMapper
	{
		public virtual ApiCustomerResponseModel MapRequestToResponse(
			int customerID,
			ApiCustomerRequestModel request)
		{
			var response = new ApiCustomerResponseModel();
			response.SetProperties(customerID,
			                       request.AccountNumber,
			                       request.ModifiedDate,
			                       request.PersonID,
			                       request.Rowguid,
			                       request.StoreID,
			                       request.TerritoryID);
			return response;
		}

		public virtual ApiCustomerRequestModel MapResponseToRequest(
			ApiCustomerResponseModel response)
		{
			var request = new ApiCustomerRequestModel();
			request.SetProperties(
				response.AccountNumber,
				response.ModifiedDate,
				response.PersonID,
				response.Rowguid,
				response.StoreID,
				response.TerritoryID);
			return request;
		}

		public JsonPatchDocument<ApiCustomerRequestModel> CreatePatch(ApiCustomerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCustomerRequestModel>();
			patch.Replace(x => x.AccountNumber, model.AccountNumber);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.PersonID, model.PersonID);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.StoreID, model.StoreID);
			patch.Replace(x => x.TerritoryID, model.TerritoryID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3832127d077a2693ff2b7c33db7ff494</Hash>
</Codenesium>*/