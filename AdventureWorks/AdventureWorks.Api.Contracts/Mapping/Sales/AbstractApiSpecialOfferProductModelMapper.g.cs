using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSpecialOfferProductModelMapper
        {
                public virtual ApiSpecialOfferProductResponseModel MapRequestToResponse(
                        int specialOfferID,
                        ApiSpecialOfferProductRequestModel request)
                {
                        var response = new ApiSpecialOfferProductResponseModel();
                        response.SetProperties(specialOfferID,
                                               request.ModifiedDate,
                                               request.ProductID,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiSpecialOfferProductRequestModel MapResponseToRequest(
                        ApiSpecialOfferProductResponseModel response)
                {
                        var request = new ApiSpecialOfferProductRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.ProductID,
                                response.Rowguid);
                        return request;
                }

                public JsonPatchDocument<ApiSpecialOfferProductRequestModel> CreatePatch(ApiSpecialOfferProductRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSpecialOfferProductRequestModel>();
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.ProductID, model.ProductID);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>3e620aa508a45c4390bd4acf55076c39</Hash>
</Codenesium>*/