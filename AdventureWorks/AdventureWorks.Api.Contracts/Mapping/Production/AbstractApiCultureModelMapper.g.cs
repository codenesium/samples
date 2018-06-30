using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCultureModelMapper
        {
                public virtual ApiCultureResponseModel MapRequestToResponse(
                        string cultureID,
                        ApiCultureRequestModel request)
                {
                        var response = new ApiCultureResponseModel();
                        response.SetProperties(cultureID,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiCultureRequestModel MapResponseToRequest(
                        ApiCultureResponseModel response)
                {
                        var request = new ApiCultureRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>32e34e066847976eb2622cb11a48d5c0</Hash>
</Codenesium>*/