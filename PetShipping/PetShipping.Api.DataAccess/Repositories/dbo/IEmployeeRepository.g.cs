using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		int Create(EmployeeModel model);

		void Update(int id,
		            EmployeeModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOEmployee GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployee> GetWhereDirect(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c57a4a971b84e2a807a2cc4ef4701c65</Hash>
</Codenesium>*/