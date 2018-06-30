using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesOrderHeaderModelMapper
        {
                ApiSalesOrderHeaderResponseModel MapRequestToResponse(
                        int salesOrderID,
                        ApiSalesOrderHeaderRequestModel request);

                ApiSalesOrderHeaderRequestModel MapResponseToRequest(
                        ApiSalesOrderHeaderResponseModel response);
        }
}

/*<Codenesium>
    <Hash>893020a8c269d8b8c026b9025362379b</Hash>
</Codenesium>*/