using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDepartmentService
	{
		Task<CreateResponse<ApiDepartmentResponseModel>> Create(
			ApiDepartmentRequestModel model);

		Task<UpdateResponse<ApiDepartmentResponseModel>> Update(short departmentID,
		                                                         ApiDepartmentRequestModel model);

		Task<ActionResponse> Delete(short departmentID);

		Task<ApiDepartmentResponseModel> Get(short departmentID);

		Task<List<ApiDepartmentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiDepartmentResponseModel> ByName(string name);

		Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(short departmentID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>229a6b6d99ba024ac4667a73a2a79764</Hash>
</Codenesium>*/