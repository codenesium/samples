using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductCategoryModelMapper
        {
                ApiProductCategoryResponseModel MapRequestToResponse(
                        int productCategoryID,
                        ApiProductCategoryRequestModel request);

                ApiProductCategoryRequestModel MapResponseToRequest(
                        ApiProductCategoryResponseModel response);

                JsonPatchDocument<ApiProductCategoryRequestModel> CreatePatch(ApiProductCategoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>c4876686b6a75d3c3175309f7230da20</Hash>
</Codenesium>*/