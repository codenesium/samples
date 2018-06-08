using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>a482a660b9ec195791252711e3f9eee0</Hash>
</Codenesium>*/