using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesOrderHeaderSalesReasonModelMapper
        {
                ApiSalesOrderHeaderSalesReasonResponseModel MapRequestToResponse(
                        int salesOrderID,
                        ApiSalesOrderHeaderSalesReasonRequestModel request);

                ApiSalesOrderHeaderSalesReasonRequestModel MapResponseToRequest(
                        ApiSalesOrderHeaderSalesReasonResponseModel response);

                JsonPatchDocument<ApiSalesOrderHeaderSalesReasonRequestModel> CreatePatch(ApiSalesOrderHeaderSalesReasonRequestModel model);
        }
}

/*<Codenesium>
    <Hash>1d486867a66685ef075262dd7ef94f8b</Hash>
</Codenesium>*/