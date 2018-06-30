using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiAddressTypeModelMapper
        {
                public virtual ApiAddressTypeResponseModel MapRequestToResponse(
                        int addressTypeID,
                        ApiAddressTypeRequestModel request)
                {
                        var response = new ApiAddressTypeResponseModel();
                        response.SetProperties(addressTypeID,
                                               request.ModifiedDate,
                                               request.Name,
                                               request.Rowguid);
                        return response;
                }

                public virtual ApiAddressTypeRequestModel MapResponseToRequest(
                        ApiAddressTypeResponseModel response)
                {
                        var request = new ApiAddressTypeRequestModel();
                        request.SetProperties(
                                response.ModifiedDate,
                                response.Name,
                                response.Rowguid);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>272febab6afc420e00f130c733b8ec29</Hash>
</Codenesium>*/