using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeePayHistoryRepository
	{
		int Create(EmployeePayHistoryModel model);

		void Update(int businessEntityID,
		            EmployeePayHistoryModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOEmployeePayHistory GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFEmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployeePayHistory> GetWhereDirect(Expression<Func<EFEmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c5b6f58aa4a3036ca2b48de04434657f</Hash>
</Codenesium>*/