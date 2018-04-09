using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICustomerRepository
	{
		int Create(Nullable<int> personID,
		           Nullable<int> storeID,
		           Nullable<int> territoryID,
		           string accountNumber,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int customerID, Nullable<int> personID,
		            Nullable<int> storeID,
		            Nullable<int> territoryID,
		            string accountNumber,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int customerID);

		Response GetById(int customerID);

		POCOCustomer GetByIdDirect(int customerID);

		Response GetWhere(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOCustomer> GetWhereDirect(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>224d6f1bfe0d8ee860ade9bb955c659e</Hash>
</Codenesium>*/