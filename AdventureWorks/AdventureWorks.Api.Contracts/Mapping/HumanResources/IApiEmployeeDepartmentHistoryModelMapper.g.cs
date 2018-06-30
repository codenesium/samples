using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public interface IApiEmployeeDepartmentHistoryModelMapper
        {
                ApiEmployeeDepartmentHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmployeeDepartmentHistoryRequestModel request);

                ApiEmployeeDepartmentHistoryRequestModel MapResponseToRequest(
                        ApiEmployeeDepartmentHistoryResponseModel response);
        }
}

/*<Codenesium>
    <Hash>468d4722d5dd1dad7f5e24a2e245412f</Hash>
</Codenesium>*/