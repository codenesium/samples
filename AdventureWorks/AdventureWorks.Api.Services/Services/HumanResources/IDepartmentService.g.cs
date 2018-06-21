using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiDepartmentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiDepartmentResponseModel> ByName(string name);

                Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(short departmentID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e08d50d0da401686a6994743896200e4</Hash>
</Codenesium>*/