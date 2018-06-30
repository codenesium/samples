using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiAddressModelMapper
        {
                public virtual ApiAddressResponseModel MapRequestToResponse(
                        int addressID,
                        ApiAddressRequestModel request)
                {
                        var response = new ApiAddressResponseModel();
                        response.SetProperties(addressID,
                                               request.AddressLine1,
                                               request.AddressLine2,
                                               request.City,
                                               request.ModifiedDate,
                                               request.PostalCode,
                                               request.Rowguid,
                                               request.StateProvinceID);
                        return response;
                }

                public virtual ApiAddressRequestModel MapResponseToRequest(
                        ApiAddressResponseModel response)
                {
                        var request = new ApiAddressRequestModel();
                        request.SetProperties(
                                response.AddressLine1,
                                response.AddressLine2,
                                response.City,
                                response.ModifiedDate,
                                response.PostalCode,
                                response.Rowguid,
                                response.StateProvinceID);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>0cbf06cea72cd41224d194ec839c4d4b</Hash>
</Codenesium>*/