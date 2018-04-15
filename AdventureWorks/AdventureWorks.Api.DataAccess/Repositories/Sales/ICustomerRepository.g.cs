using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICustomerRepository
	{
		int Create(CustomerModel model);

		void Update(int customerID,
		            CustomerModel model);

		void Delete(int customerID);

		ApiResponse GetById(int customerID);

		POCOCustomer GetByIdDirect(int customerID);

		ApiResponse GetWhere(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCustomer> GetWhereDirect(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>22f3309baf07b0e3c2de8699fcc45a41</Hash>
</Codenesium>*/