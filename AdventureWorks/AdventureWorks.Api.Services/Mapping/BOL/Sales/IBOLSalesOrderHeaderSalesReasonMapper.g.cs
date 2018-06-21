using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>ceecf2abe3f97d7c432ffe337b28445f</Hash>
</Codenesium>*/