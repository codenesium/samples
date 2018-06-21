using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSalesOrderDetailMapper
        {
                BOSalesOrderDetail MapModelToBO(
                        int salesOrderID,
                        ApiSalesOrderDetailRequestModel model);

                ApiSalesOrderDetailResponseModel MapBOToModel(
                        BOSalesOrderDetail boSalesOrderDetail);

                List<ApiSalesOrderDetailResponseModel> MapBOToModel(
                        List<BOSalesOrderDetail> items);
        }
}

/*<Codenesium>
    <Hash>a69507f3ad6610e63e3b29be84a9df8b</Hash>
</Codenesium>*/