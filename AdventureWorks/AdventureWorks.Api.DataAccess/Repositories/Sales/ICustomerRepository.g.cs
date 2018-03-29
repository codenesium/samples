using System;
using System.Linq.Expressions;
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

		void GetById(int customerID, Response response);

		void GetWhere(Expression<Func<EFCustomer, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f515b1b4776a58eab552338ebbd0cb2b</Hash>
</Codenesium>*/