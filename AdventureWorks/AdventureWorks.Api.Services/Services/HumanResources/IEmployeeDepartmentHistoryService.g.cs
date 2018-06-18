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

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByDepartmentID(short departmentID);
                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByShiftID(int shiftID);
        }
}

/*<Codenesium>
    <Hash>e4fea13108a4e672d17483acafea9894</Hash>
</Codenesium>*/