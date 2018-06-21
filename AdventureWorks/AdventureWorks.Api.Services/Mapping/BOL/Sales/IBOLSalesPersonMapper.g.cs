using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>2ad66a8268e2070764533cbe92ad6597</Hash>
</Codenesium>*/