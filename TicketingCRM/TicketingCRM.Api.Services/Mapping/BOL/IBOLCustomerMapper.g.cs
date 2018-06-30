using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLCustomerMapper
        {
                BOCustomer MapModelToBO(
                        int id,
                        ApiCustomerRequestModel model);

                ApiCustomerResponseModel MapBOToModel(
                        BOCustomer boCustomer);

                List<ApiCustomerResponseModel> MapBOToModel(
                        List<BOCustomer> items);
        }
}

/*<Codenesium>
    <Hash>b80e3548922c384c3b261eeea1cdd401</Hash>
</Codenesium>*/