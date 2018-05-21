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
		Task<CreateResponse<POCOEmployeeDepartmentHistory>> Create(
			ApiEmployeeDepartmentHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiEmployeeDepartmentHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOEmployeeDepartmentHistory> Get(int businessEntityID);

		Task<List<POCOEmployeeDepartmentHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOEmployeeDepartmentHistory>> GetDepartmentID(short departmentID);
		Task<List<POCOEmployeeDepartmentHistory>> GetShiftID(int shiftID);
	}
}

/*<Codenesium>
    <Hash>1c106df33cb1e0fa8aad9bb42e3c57be</Hash>
</Codenesium>*/