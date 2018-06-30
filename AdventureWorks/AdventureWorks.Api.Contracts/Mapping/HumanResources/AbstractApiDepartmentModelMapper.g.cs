using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiDepartmentModelMapper
        {
                public virtual ApiDepartmentResponseModel MapRequestToResponse(
                        short departmentID,
                        ApiDepartmentRequestModel request)
                {
                        var response = new ApiDepartmentResponseModel();
                        response.SetProperties(departmentID,
                                               request.GroupName,
                                               request.ModifiedDate,
                                               request.Name);
                        return response;
                }

                public virtual ApiDepartmentRequestModel MapResponseToRequest(
                        ApiDepartmentResponseModel response)
                {
                        var request = new ApiDepartmentRequestModel();
                        request.SetProperties(
                                response.GroupName,
                                response.ModifiedDate,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>2125a6815e7b28eebc1159e726f18523</Hash>
</Codenesium>*/