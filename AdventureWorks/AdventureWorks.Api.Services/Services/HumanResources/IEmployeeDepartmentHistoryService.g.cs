using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IEmployeeDepartmentHistoryService
        {
                Task<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Create(
                        ApiEmployeeDepartmentHistoryRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiEmployeeDepartmentHistoryRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiEmployeeDepartmentHistoryResponseModel> Get(int businessEntityID);

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetDepartmentID(short departmentID);
                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetShiftID(int shiftID);
        }
}

/*<Codenesium>
    <Hash>602a72aaf0e69d0b7eba670adb5c2e94</Hash>
</Codenesium>*/