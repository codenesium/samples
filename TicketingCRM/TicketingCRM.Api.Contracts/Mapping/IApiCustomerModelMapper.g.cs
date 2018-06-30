using System;
using System.Collections.Generic;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiCustomerModelMapper
        {
                ApiCustomerResponseModel MapRequestToResponse(
                        int id,
                        ApiCustomerRequestModel request);

                ApiCustomerRequestModel MapResponseToRequest(
                        ApiCustomerResponseModel response);
        }
}

/*<Codenesium>
    <Hash>41a53e45c06a897a226581a0603dc1bf</Hash>
</Codenesium>*/