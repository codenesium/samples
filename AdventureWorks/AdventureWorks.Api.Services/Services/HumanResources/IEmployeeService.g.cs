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

		Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEmployeePayHistoryResponseModel>> EmployeePayHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiJobCandidateResponseModel>> JobCandidates(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>45f2866636d46a8684552b2eac250cce</Hash>
</Codenesium>*/