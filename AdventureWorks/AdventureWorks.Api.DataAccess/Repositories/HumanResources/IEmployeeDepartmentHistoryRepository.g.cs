using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeDepartmentHistoryRepository
	{
		int Create(short departmentID,
		           int shiftID,
		           DateTime startDate,
		           Nullable<DateTime> endDate,
		           DateTime modifiedDate);

		void Update(int businessEntityID, short departmentID,
		            int shiftID,
		            DateTime startDate,
		            Nullable<DateTime> endDate,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		Response GetById(int businessEntityID);

		POCOEmployeeDepartmentHistory GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOEmployeeDepartmentHistory> GetWhereDirect(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d0b9cde53652d7f66d9e0add7ae881b1</Hash>
</Codenesium>*/