using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOEmployee
	{
		Task<CreateResponse<int>> Create(
			EmployeeModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            EmployeeModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOEmployee GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployee> GetWhereDirect(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a0c2ebf7dda8a4f679a66e7a6056fc7c</Hash>
</Codenesium>*/