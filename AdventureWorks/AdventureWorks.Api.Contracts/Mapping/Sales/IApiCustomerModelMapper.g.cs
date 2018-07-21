using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiCustomerModelMapper
        {
                ApiCustomerResponseModel MapRequestToResponse(
                        int customerID,
                        ApiCustomerRequestModel request);

                ApiCustomerRequestModel MapResponseToRequest(
                        ApiCustomerResponseModel response);

                JsonPatchDocument<ApiCustomerRequestModel> CreatePatch(ApiCustomerRequestModel model);
        }
}

/*<Codenesium>
    <Hash>70b7f4a5d89f97ead77f89af6ae8f67f</Hash>
</Codenesium>*/