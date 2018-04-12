using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICustomerRepository
	{
		int Create(
			Nullable<int> personID,
			Nullable<int> storeID,
			Nullable<int> territoryID,
			string accountNumber,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int customerID,
		            Nullable<int> personID,
		            Nullable<int> storeID,
		            Nullable<int> territoryID,
		            string accountNumber,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int customerID);

		Response GetById(int customerID);

		POCOCustomer GetByIdDirect(int customerID);

		Response GetWhere(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCustomer> GetWhereDirect(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ed9350fd50bfca0920180d435106011f</Hash>
</Codenesium>*/