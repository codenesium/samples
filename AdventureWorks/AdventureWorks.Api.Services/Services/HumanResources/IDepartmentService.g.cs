using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDepartmentService
        {
                Task<CreateResponse<ApiDepartmentResponseModel>> Create(
                        ApiDepartmentRequestModel model);

                Task<ActionResponse> Update(short departmentID,
                                            ApiDepartmentRequestModel model);

                Task<ActionResponse> Delete(short departmentID);

                Task<ApiDepartmentResponseModel> Get(short departmentID);

                Task<List<ApiDepartmentResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiDepartmentResponseModel> GetName(string name);

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(short departmentID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>620e09ce723310c53dd8a2c6976fed1d</Hash>
</Codenesium>*/