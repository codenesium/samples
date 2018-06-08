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

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetDepartmentID(short departmentID);
                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetShiftID(int shiftID);
        }
}

/*<Codenesium>
    <Hash>a331befc6c8cba693e3cb4c5930dba9a</Hash>
</Codenesium>*/