using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOEmployee
	{
		Task<CreateResponse<int>> Create(
			EmployeeModel model);

		Task<ActionResponse> Update(int id,
		                            EmployeeModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOEmployee GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmployee> GetWhereDirect(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>06cbeb231dfa888af51e5d049047bd93</Hash>
</Codenesium>*/