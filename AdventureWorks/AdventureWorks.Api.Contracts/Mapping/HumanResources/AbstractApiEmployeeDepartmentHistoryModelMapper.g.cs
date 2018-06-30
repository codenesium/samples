using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiEmployeeDepartmentHistoryModelMapper
        {
                public virtual ApiEmployeeDepartmentHistoryResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmployeeDepartmentHistoryRequestModel request)
                {
                        var response = new ApiEmployeeDepartmentHistoryResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.DepartmentID,
                                               request.EndDate,
                                               request.ModifiedDate,
                                               request.ShiftID,
                                               request.StartDate);
                        return response;
                }

                public virtual ApiEmployeeDepartmentHistoryRequestModel MapResponseToRequest(
                        ApiEmployeeDepartmentHistoryResponseModel response)
                {
                        var request = new ApiEmployeeDepartmentHistoryRequestModel();
                        request.SetProperties(
                                response.DepartmentID,
                                response.EndDate,
                                response.ModifiedDate,
                                response.ShiftID,
                                response.StartDate);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>c7d4e86b4fc852487a5d5c3df2cbbb09</Hash>
</Codenesium>*/