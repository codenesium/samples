using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IEmployeeDepartmentHistoryService
	{
		Task<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Create(
			ApiEmployeeDepartmentHistoryRequestModel model);

		Task<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Update(int businessEntityID,
		                                                                        ApiEmployeeDepartmentHistoryRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiEmployeeDepartmentHistoryResponseModel> Get(int businessEntityID);

		Task<List<ApiEmployeeDepartmentHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByDepartmentID(short departmentID);

		Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByShiftID(int shiftID);
	}
}

/*<Codenesium>
    <Hash>1374efac408f90a585a5fb3c53c28f3a</Hash>
</Codenesium>*/