using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSalesOrderHeaderSalesReasonMapper
        {
                BOSalesOrderHeaderSalesReason MapModelToBO(
                        int salesOrderID,
                        ApiSalesOrderHeaderSalesReasonRequestModel model);

                ApiSalesOrderHeaderSalesReasonResponseModel MapBOToModel(
                        BOSalesOrderHeaderSalesReason boSalesOrderHeaderSalesReason);

                List<ApiSalesOrderHeaderSalesReasonResponseModel> MapBOToModel(
                        List<BOSalesOrderHeaderSalesReason> items);
        }
}

/*<Codenesium>
    <Hash>12a99f7d6f9b2989879e5638a6670fb9</Hash>
</Codenesium>*/