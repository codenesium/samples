using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSpecialOfferModelMapper
        {
                public virtual ApiSpecialOfferResponseModel MapRequestToResponse(
                        int specialOfferID,
                        ApiSpecialOfferRequestModel request)
                {
                        var response = new ApiSpecialOfferResponseModel();
                        response.SetProperties(specialOfferID,
                                               request.Category,
                                               request.Description,
                                               request.DiscountPct,
                                               request.EndDate,
                                               request.MaxQty,
                                               request.MinQty,
                                               request.ModifiedDate,
                                               request.Rowguid,
                                               request.StartDate,
                                               request.Type);
                        return response;
                }

                public virtual ApiSpecialOfferRequestModel MapResponseToRequest(
                        ApiSpecialOfferResponseModel response)
                {
                        var request = new ApiSpecialOfferRequestModel();
                        request.SetProperties(
                                response.Category,
                                response.Description,
                                response.DiscountPct,
                                response.EndDate,
                                response.MaxQty,
                                response.MinQty,
                                response.ModifiedDate,
                                response.Rowguid,
                                response.StartDate,
                                response.Type);
                        return request;
                }

                public JsonPatchDocument<ApiSpecialOfferRequestModel> CreatePatch(ApiSpecialOfferRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiSpecialOfferRequestModel>();
                        patch.Replace(x => x.Category, model.Category);
                        patch.Replace(x => x.Description, model.Description);
                        patch.Replace(x => x.DiscountPct, model.DiscountPct);
                        patch.Replace(x => x.EndDate, model.EndDate);
                        patch.Replace(x => x.MaxQty, model.MaxQty);
                        patch.Replace(x => x.MinQty, model.MinQty);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        patch.Replace(x => x.StartDate, model.StartDate);
                        patch.Replace(x => x.Type, model.Type);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>af21e8bfa74c755678ade4e7dbc6a30e</Hash>
</Codenesium>*/