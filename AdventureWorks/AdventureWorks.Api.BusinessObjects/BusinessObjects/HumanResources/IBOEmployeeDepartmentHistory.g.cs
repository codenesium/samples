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

		ApiResponse GetById(int businessEntityID);

		POCOEmployeeDepartmentHistory GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployeeDepartmentHistory> GetWhereDirect(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1c10c3d4c7f777472ad686238d611109</Hash>
</Codenesium>*/