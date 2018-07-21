using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiBusinessEntityContactModelMapper
        {
                public virtual ApiBusinessEntityContactResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityContactRequestModel request)
                {
                        var response = new ApiBusinessEntityContactResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.ContactTypeID,
                                               request.ModifiedDate,
                                               request.PersonID,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiBusinessEntityContactRequestModel MapResponseToRequest(
                        ApiBusinessEntityContactResponseModel response)
                {
                        var request = new ApiBusinessEntityContactRequestModel();
                        request.SetProperties(
                                response.ContactTypeID,
                                response.ModifiedDate,
                                response.PersonID,
                                response.Rowguid);
                        return request;
                }

                public JsonPatchDocument<ApiBusinessEntityContactRequestModel> CreatePatch(ApiBusinessEntityContactRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiBusinessEntityContactRequestModel>();
                        patch.Replace(x => x.ContactTypeID, model.ContactTypeID);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.PersonID, model.PersonID);
                        patch.Replace(x => x.Rowguid, model.Rowguid);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>1de72defb668596585c03f537e6bc5e2</Hash>
</Codenesium>*/