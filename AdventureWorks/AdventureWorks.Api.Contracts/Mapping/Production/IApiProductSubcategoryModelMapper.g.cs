using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductSubcategoryModelMapper
        {
                ApiProductSubcategoryResponseModel MapRequestToResponse(
                        int productSubcategoryID,
                        ApiProductSubcategoryRequestModel request);

                ApiProductSubcategoryRequestModel MapResponseToRequest(
                        ApiProductSubcategoryResponseModel response);

                JsonPatchDocument<ApiProductSubcategoryRequestModel> CreatePatch(ApiProductSubcategoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>9cdfb15114bbd9c7e4048eb86f7a704e</Hash>
</Codenesium>*/