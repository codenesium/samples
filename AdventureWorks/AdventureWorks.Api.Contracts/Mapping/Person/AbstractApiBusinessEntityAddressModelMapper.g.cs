using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiBusinessEntityAddressModelMapper
        {
                public virtual ApiBusinessEntityAddressResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiBusinessEntityAddressRequestModel request)
                {
                        var response = new ApiBusinessEntityAddressResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.AddressID,
                                               request.AddressTypeID,
                                               request.ModifiedDate,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiBusinessEntityAddressRequestModel MapResponseToRequest(
                        ApiBusinessEntityAddressResponseModel response)
                {
                        var request = new ApiBusinessEntityAddressRequestModel();
                        request.SetProperties(
                                response.AddressID,
                                response.AddressTypeID,
                                response.ModifiedDate,
                                response.Rowguid);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>9fd0ce7bf175ef1d912bfb99b502fe65</Hash>
</Codenesium>*/