using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesOrderDetailModelMapper
        {
                ApiSalesOrderDetailResponseModel MapRequestToResponse(
                        int salesOrderID,
                        ApiSalesOrderDetailRequestModel request);

                ApiSalesOrderDetailRequestModel MapResponseToRequest(
                        ApiSalesOrderDetailResponseModel response);

                JsonPatchDocument<ApiSalesOrderDetailRequestModel> CreatePatch(ApiSalesOrderDetailRequestModel model);
        }
}

/*<Codenesium>
    <Hash>3332be1ceba6f2bb1c6868e93f0f09fb</Hash>
</Codenesium>*/