using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiSalesReasonModelMapper
        {
                ApiSalesReasonResponseModel MapRequestToResponse(
                        int salesReasonID,
                        ApiSalesReasonRequestModel request);

                ApiSalesReasonRequestModel MapResponseToRequest(
                        ApiSalesReasonResponseModel response);

                JsonPatchDocument<ApiSalesReasonRequestModel> CreatePatch(ApiSalesReasonRequestModel model);
        }
}

/*<Codenesium>
    <Hash>830ae6be57243c253556473b846bbf67</Hash>
</Codenesium>*/