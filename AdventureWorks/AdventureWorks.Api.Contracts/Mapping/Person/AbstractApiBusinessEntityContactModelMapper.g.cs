using System;
using System.Collections.Generic;

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
        }
}

/*<Codenesium>
    <Hash>47b98ad815ae8393d082edf596dccfa5</Hash>
</Codenesium>*/