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

                Task<List<ApiEmployeeResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiEmployeeResponseModel> GetLoginID(string loginID);
                Task<ApiEmployeeResponseModel> GetNationalIDNumber(string nationalIDNumber);
                Task<List<ApiEmployeeResponseModel>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel, Nullable<Guid> organizationNode);
                Task<List<ApiEmployeeResponseModel>> GetOrganizationNode(Nullable<Guid> organizationNode);

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiJobCandidateResponseModel>> JobCandidates(int businessEntityID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8640e5a93ae8b28586e24bfe4f15fd7b</Hash>
</Codenesium>*/