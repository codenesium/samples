using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiEmployeePayHistoryModelMapper
        {
                ApiEmployeePayHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmployeePayHistoryRequestModel request);

                ApiEmployeePayHistoryRequestModel MapResponseToRequest(
                        ApiEmployeePayHistoryResponseModel response);

                JsonPatchDocument<ApiEmployeePayHistoryRequestModel> CreatePatch(ApiEmployeePayHistoryRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e99f7f024da01bbbd52d96273b90af65</Hash>
</Codenesium>*/