using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>25545814f516db772c0a4d5450eba2e2</Hash>
</Codenesium>*/