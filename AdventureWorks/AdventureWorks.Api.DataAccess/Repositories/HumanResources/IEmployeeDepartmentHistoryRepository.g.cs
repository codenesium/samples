using System;
using System.Linq.Expressions;
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

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>47a1d05a9dea34053f058573dea6b1cd</Hash>
</Codenesium>*/