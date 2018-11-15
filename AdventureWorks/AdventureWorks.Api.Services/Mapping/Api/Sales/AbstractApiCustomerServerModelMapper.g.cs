using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCustomerServerModelMapper
	{
		public virtual ApiCustomerServerResponseModel MapServerRequestToResponse(
			int customerID,
			ApiCustomerServerRequestModel request)
		{
			var response = new ApiCustomerServerResponseModel();
			response.SetProperties(customerID,
			                       request.AccountNumber,
			                       request.ModifiedDate,
			                       request.PersonID,
			                       request.Rowguid,
			                       request.StoreID,
			                       request.TerritoryID);
			return response;
		}

		public virtual ApiCustomerServerRequestModel MapServerResponseToRequest(
			ApiCustomerServerResponseModel response)
		{
			var request = new ApiCustomerServerRequestModel();
			request.SetProperties(
				response.AccountNumber,
				response.ModifiedDate,
				response.PersonID,
				response.Rowguid,
				response.StoreID,
				response.TerritoryID);
			return request;
		}

		public virtual ApiCustomerClientRequestModel MapServerResponseToClientRequest(
			ApiCustomerServerResponseModel response)
		{
			var request = new ApiCustomerClientRequestModel();
			request.SetProperties(
				response.AccountNumber,
				response.ModifiedDate,
				response.PersonID,
				response.Rowguid,
				response.StoreID,
				response.TerritoryID);
			return request;
		}

		public JsonPatchDocument<ApiCustomerServerRequestModel> CreatePatch(ApiCustomerServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCustomerServerRequestModel>();
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
    <Hash>320b73e4516e2a7a89538eb9acd0d116</Hash>
</Codenesium>*/