using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesOrderDetailModelMapper
        {
                ApiSalesOrderDetailResponseModel MapRequestToResponse(
                        int salesOrderID,
                        ApiSalesOrderDetailRequestModel request);

                ApiSalesOrderDetailRequestModel MapResponseToRequest(
                        ApiSalesOrderDetailResponseModel response);
        }
}

/*<Codenesium>
    <Hash>98c48417c30cf059ff2c5c392fdaf062</Hash>
</Codenesium>*/