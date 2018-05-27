using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOEmployeeDepartmentHistory
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
    <Hash>e8e2c9d13a9b13f8fb1b90cec3e2fd03</Hash>
</Codenesium>*/