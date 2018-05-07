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
		Task<CreateResponse<int>> Create(
			EmployeeDepartmentHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            EmployeeDepartmentHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOEmployeeDepartmentHistory Get(int businessEntityID);

		List<POCOEmployeeDepartmentHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>74e4067d960da31572cbbf6accdd2637</Hash>
</Codenesium>*/