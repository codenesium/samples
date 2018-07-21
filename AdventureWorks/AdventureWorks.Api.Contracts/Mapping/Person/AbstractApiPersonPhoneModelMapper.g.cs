using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPersonPhoneModelMapper
        {
                public virtual ApiPersonPhoneResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonPhoneRequestModel request)
                {
                        var response = new ApiPersonPhoneResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.ModifiedDate,
                                               request.PhoneNumber,
                                               request.PhoneNumberTypeID);
                        return response;
                }

                public virtual ApiPersonPhoneRequestModel MapResponseToRequest(
                        ApiPersonPhoneResponseModel response)
                {
                        var request = new ApiPersonPhoneRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.PhoneNumber,
                                response.PhoneNumberTypeID);
                        return request;
                }

                public JsonPatchDocument<ApiPersonPhoneRequestModel> CreatePatch(ApiPersonPhoneRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiPersonPhoneRequestModel>();
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.PhoneNumber, model.PhoneNumber);
                        patch.Replace(x => x.PhoneNumberTypeID, model.PhoneNumberTypeID);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>3ebcfd7a938cf10974dfbdbabb0aae47</Hash>
</Codenesium>*/