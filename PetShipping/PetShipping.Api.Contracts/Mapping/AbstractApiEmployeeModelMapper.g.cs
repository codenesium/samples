using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiEmployeeModelMapper
        {
                public virtual ApiEmployeeResponseModel MapRequestToResponse(
                        int id,
                        ApiEmployeeRequestModel request)
                {
                        var response = new ApiEmployeeResponseModel();
                        response.SetProperties(id,
                                               request.FirstName,
                                               request.IsSalesPerson,
                                               request.IsShipper,
                                               request.LastName);
                        return response;
                }

                public virtual ApiEmployeeRequestModel MapResponseToRequest(
                        ApiEmployeeResponseModel response)
                {
                        var request = new ApiEmployeeRequestModel();
                        request.SetProperties(
                                response.FirstName,
                                response.IsSalesPerson,
                                response.IsShipper,
                                response.LastName);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>cdc13b704d1904f979e5f162f8882054</Hash>
</Codenesium>*/