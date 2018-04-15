using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeDepartmentHistoryRepository
	{
		int Create(EmployeeDepartmentHistoryModel model);

		void Update(int businessEntityID,
		            EmployeeDepartmentHistoryModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOEmployeeDepartmentHistory GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployeeDepartmentHistory> GetWhereDirect(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>00399561b43e05a23a098eee7e8f2d56</Hash>
</Codenesium>*/