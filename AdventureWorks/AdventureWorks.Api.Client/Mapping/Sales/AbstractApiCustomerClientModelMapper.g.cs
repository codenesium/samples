using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiCustomerModelMapper
	{
		public virtual ApiCustomerClientResponseModel MapClientRequestToResponse(
			int customerID,
			ApiCustomerClientRequestModel request)
		{
			var response = new ApiCustomerClientResponseModel();
			response.SetProperties(customerID,
			                       request.AccountNumber,
			                       request.ModifiedDate,
			                       request.PersonID,
			                       request.Rowguid,
			                       request.StoreID,
			                       request.TerritoryID);
			return response;
		}

		public virtual ApiCustomerClientRequestModel MapClientResponseToRequest(
			ApiCustomerClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>721ba6421491707205e7843517f22e39</Hash>
</Codenesium>*/