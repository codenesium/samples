using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiEmployeeDepartmentHistoryModelMapper
        {
                ApiEmployeeDepartmentHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmployeeDepartmentHistoryRequestModel request);

                ApiEmployeeDepartmentHistoryRequestModel MapResponseToRequest(
                        ApiEmployeeDepartmentHistoryResponseModel response);

                JsonPatchDocument<ApiEmployeeDepartmentHistoryRequestModel> CreatePatch(ApiEmployeeDepartmentHistoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>6101d34c3e1cfb6be8397eb84c7be978</Hash>
</Codenesium>*/