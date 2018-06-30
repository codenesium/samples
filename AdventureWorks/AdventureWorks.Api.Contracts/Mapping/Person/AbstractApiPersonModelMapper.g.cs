using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPersonModelMapper
        {
                public virtual ApiPersonResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiPersonRequestModel request)
                {
                        var response = new ApiPersonResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.AdditionalContactInfo,
                                               request.Demographics,
                                               request.EmailPromotion,
                                               request.FirstName,
                                               request.LastName,
                                               request.MiddleName,
                                               request.ModifiedDate,
                                               request.NameStyle,
                                               request.PersonType,
                                               request.Rowguid,
                                               request.Suffix,
                                               request.Title);
                        return response;
                }

                public virtual ApiPersonRequestModel MapResponseToRequest(
                        ApiPersonResponseModel response)
                {
                        var request = new ApiPersonRequestModel();
                        request.SetProperties(
                                response.AdditionalContactInfo,
                                response.Demographics,
                                response.EmailPromotion,
                                response.FirstName,
                                response.LastName,
                                response.MiddleName,
                                response.ModifiedDate,
                                response.NameStyle,
                                response.PersonType,
                                response.Rowguid,
                                response.Suffix,
                                response.Title);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>47e1f481da7fd6f1f735fd6df874e12b</Hash>
</Codenesium>*/