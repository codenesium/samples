using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IEmployeeService
	{
		Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model);

		Task<UpdateResponse<ApiEmployeeResponseModel>> Update(int businessEntityID,
		                                                       ApiEmployeeRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiEmployeeResponseModel> Get(int businessEntityID);

		Task<List<ApiEmployeeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiEmployeeResponseModel> ByLoginID(string loginID);

		Task<ApiEmployeeResponseModel> ByNationalIDNumber(string nationalIDNumber);

		Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiJobCandidateResponseModel>> JobCandidatesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0f02848079282a3cd526599feea30b4c</Hash>
</Codenesium>*/