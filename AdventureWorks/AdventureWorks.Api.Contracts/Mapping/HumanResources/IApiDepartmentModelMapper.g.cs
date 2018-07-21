using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiDepartmentModelMapper
        {
                ApiDepartmentResponseModel MapRequestToResponse(
                        short departmentID,
                        ApiDepartmentRequestModel request);

                ApiDepartmentRequestModel MapResponseToRequest(
                        ApiDepartmentResponseModel response);

                JsonPatchDocument<ApiDepartmentRequestModel> CreatePatch(ApiDepartmentRequestModel model);
        }
}

/*<Codenesium>
    <Hash>1f96ad805f67ee280bceb9bfdfc6564a</Hash>
</Codenesium>*/