using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductModelIllustrationModelMapper
        {
                public virtual ApiProductModelIllustrationResponseModel MapRequestToResponse(
                        int productModelID,
                        ApiProductModelIllustrationRequestModel request)
                {
                        var response = new ApiProductModelIllustrationResponseModel();
                        response.SetProperties(productModelID,
                                               request.IllustrationID,
                                               request.ModifiedDate);
                        return response;
                }

                public virtual ApiProductModelIllustrationRequestModel MapResponseToRequest(
                        ApiProductModelIllustrationResponseModel response)
                {
                        var request = new ApiProductModelIllustrationRequestModel();
                        request.SetProperties(
                                response.IllustrationID,
                                response.ModifiedDate);
                        return request;
                }

                public JsonPatchDocument<ApiProductModelIllustrationRequestModel> CreatePatch(ApiProductModelIllustrationRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiProductModelIllustrationRequestModel>();
                        patch.Replace(x => x.IllustrationID, model.IllustrationID);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>cbebc8354fbbdc8d088f7120465390be</Hash>
</Codenesium>*/