using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IEmployeeService
        {
                Task<CreateResponse<ApiEmployeeResponseModel>> Create(
                        ApiEmployeeRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiEmployeeRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiEmployeeResponseModel> Get(int businessEntityID);

                Task<List<ApiEmployeeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiEmployeeResponseModel> ByLoginID(string loginID);
                Task<ApiEmployeeResponseModel> ByNationalIDNumber(string nationalIDNumber);

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiJobCandidateResponseModel>> JobCandidates(int businessEntityID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6dd404ea35865a31709e2ee51eb3b4d8</Hash>
</Codenesium>*/