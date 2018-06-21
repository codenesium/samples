using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>8bf759984f3b1f3169cd64b955fbe396</Hash>
</Codenesium>*/