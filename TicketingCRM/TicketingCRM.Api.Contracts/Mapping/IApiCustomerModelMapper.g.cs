using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiCustomerModelMapper
        {
                ApiCustomerResponseModel MapRequestToResponse(
                        int id,
                        ApiCustomerRequestModel request);

                ApiCustomerRequestModel MapResponseToRequest(
                        ApiCustomerResponseModel response);

                JsonPatchDocument<ApiCustomerRequestModel> CreatePatch(ApiCustomerRequestModel model);
        }
}

/*<Codenesium>
    <Hash>2e496a977c8579e37bd144e40f1b3187</Hash>
</Codenesium>*/