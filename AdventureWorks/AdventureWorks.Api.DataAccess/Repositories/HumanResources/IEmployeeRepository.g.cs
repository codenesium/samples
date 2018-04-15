using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		int Create(EmployeeModel model);

		void Update(int businessEntityID,
		            EmployeeModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOEmployee GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployee> GetWhereDirect(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9bb175cb1418544c932fb013f487646a</Hash>
</Codenesium>*/