using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiProductDescriptionModelMapper
        {
                ApiProductDescriptionResponseModel MapRequestToResponse(
                        int productDescriptionID,
                        ApiProductDescriptionRequestModel request);

                ApiProductDescriptionRequestModel MapResponseToRequest(
                        ApiProductDescriptionResponseModel response);

                JsonPatchDocument<ApiProductDescriptionRequestModel> CreatePatch(ApiProductDescriptionRequestModel model);
        }
}

/*<Codenesium>
    <Hash>4fafbedba91dec2a0ec2eb17949b66b6</Hash>
</Codenesium>*/