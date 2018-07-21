using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiDepartmentRequestModel> CreatePatch(ApiDepartmentRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiDepartmentRequestModel>();
                        patch.Replace(x => x.GroupName, model.GroupName);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>549a2f656a724f7fce9db6950a43393d</Hash>
</Codenesium>*/