using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiDepartmentModelMapper
        {
                ApiDepartmentResponseModel MapRequestToResponse(
                        short departmentID,
                        ApiDepartmentRequestModel request);

                ApiDepartmentRequestModel MapResponseToRequest(
                        ApiDepartmentResponseModel response);
        }
}

/*<Codenesium>
    <Hash>76afe96b1393a33f0e50889f61ac1305</Hash>
</Codenesium>*/