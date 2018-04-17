using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCustomer
	{
		Task<CreateResponse<int>> Create(
			CustomerModel model);

		Task<ActionResponse> Update(int customerID,
		                            CustomerModel model);

		Task<ActionResponse> Delete(int customerID);

		ApiResponse GetById(int customerID);

		POCOCustomer GetByIdDirect(int customerID);

		ApiResponse GetWhere(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCustomer> GetWhereDirect(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c6e6cf40c326a094e02f589384505322</Hash>
</Codenesium>*/