using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSalesOrderHeaderMapper
        {
                BOSalesOrderHeader MapModelToBO(
                        int salesOrderID,
                        ApiSalesOrderHeaderRequestModel model);

                ApiSalesOrderHeaderResponseModel MapBOToModel(
                        BOSalesOrderHeader boSalesOrderHeader);

                List<ApiSalesOrderHeaderResponseModel> MapBOToModel(
                        List<BOSalesOrderHeader> items);
        }
}

/*<Codenesium>
    <Hash>82b7d3ca4ef74770c3a34a6c1b39af07</Hash>
</Codenesium>*/