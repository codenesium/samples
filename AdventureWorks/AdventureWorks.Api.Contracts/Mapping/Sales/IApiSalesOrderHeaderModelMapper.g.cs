using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesOrderHeaderModelMapper
        {
                ApiSalesOrderHeaderResponseModel MapRequestToResponse(
                        int salesOrderID,
                        ApiSalesOrderHeaderRequestModel request);

                ApiSalesOrderHeaderRequestModel MapResponseToRequest(
                        ApiSalesOrderHeaderResponseModel response);

                JsonPatchDocument<ApiSalesOrderHeaderRequestModel> CreatePatch(ApiSalesOrderHeaderRequestModel model);
        }
}

/*<Codenesium>
    <Hash>8b47d9aa9e8af8a3e38132918258b408</Hash>
</Codenesium>*/