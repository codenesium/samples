using System;
using System.Collections.Generic;

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
        }
}

/*<Codenesium>
    <Hash>4f5efe2b45ef533a70c07580824da6b0</Hash>
</Codenesium>*/