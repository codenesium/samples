using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLCustomerMapper
        {
                BOCustomer MapModelToBO(
                        int customerID,
                        ApiCustomerRequestModel model);

                ApiCustomerResponseModel MapBOToModel(
                        BOCustomer boCustomer);

                List<ApiCustomerResponseModel> MapBOToModel(
                        List<BOCustomer> items);
        }
}

/*<Codenesium>
    <Hash>399d29d62df88c6b48675627b3e1700d</Hash>
</Codenesium>*/