using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSalesPersonMapper
        {
                BOSalesPerson MapModelToBO(
                        int businessEntityID,
                        ApiSalesPersonRequestModel model);

                ApiSalesPersonResponseModel MapBOToModel(
                        BOSalesPerson boSalesPerson);

                List<ApiSalesPersonResponseModel> MapBOToModel(
                        List<BOSalesPerson> items);
        }
}

/*<Codenesium>
    <Hash>1d3ad2cbbf816b10088a32724b44191f</Hash>
</Codenesium>*/