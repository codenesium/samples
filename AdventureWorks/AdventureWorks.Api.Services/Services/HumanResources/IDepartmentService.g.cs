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

		Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoriesByDepartmentID(short departmentID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>219f7534b521ef2f412e4d8c86c38f83</Hash>
</Codenesium>*/