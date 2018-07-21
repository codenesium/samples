using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductModelProductDescriptionCultureModelMapper
        {
                ApiProductModelProductDescriptionCultureResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelProductDescriptionCultureRequestModel request);

                ApiProductModelProductDescriptionCultureRequestModel MapResponseToRequest(
                        ApiProductModelProductDescriptionCultureResponseModel response);

                JsonPatchDocument<ApiProductModelProductDescriptionCultureRequestModel> CreatePatch(ApiProductModelProductDescriptionCultureRequestModel model);
        }
}

/*<Codenesium>
    <Hash>631aa249cb4c7c9d289b111919b97296</Hash>
</Codenesium>*/