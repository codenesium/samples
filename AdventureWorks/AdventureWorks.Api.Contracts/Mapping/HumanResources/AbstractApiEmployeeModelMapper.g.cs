using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiEmployeeModelMapper
        {
                public virtual ApiEmployeeResponseModel MapRequestToResponse(
                        int businessEntityID,
                        ApiEmployeeRequestModel request)
                {
                        var response = new ApiEmployeeResponseModel();
                        response.SetProperties(businessEntityID,
                                               request.BirthDate,
                                               request.CurrentFlag,
                                               request.Gender,
                                               request.HireDate,
                                               request.JobTitle,
                                               request.LoginID,
                                               request.MaritalStatus,
                                               request.ModifiedDate,
                                               request.NationalIDNumber,
                                               request.OrganizationLevel,
                                               request.Rowguid,
                                               request.SalariedFlag,
                                               request.SickLeaveHours,
                                               request.VacationHours);
                        return response;
                }

                public virtual ApiEmployeeRequestModel MapResponseToRequest(
                        ApiEmployeeResponseModel response)
                {
                        var request = new ApiEmployeeRequestModel();
                        request.SetProperties(
                                response.BirthDate,
                                response.CurrentFlag,
                                response.Gender,
                                response.HireDate,
                                response.JobTitle,
                                response.LoginID,
                                response.MaritalStatus,
                                response.ModifiedDate,
                                response.NationalIDNumber,
                                response.OrganizationLevel,
                                response.Rowguid,
                                response.SalariedFlag,
                                response.SickLeaveHours,
                                response.VacationHours);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>e42419162868e824f8de6ef62dbc45eb</Hash>
</Codenesium>*/