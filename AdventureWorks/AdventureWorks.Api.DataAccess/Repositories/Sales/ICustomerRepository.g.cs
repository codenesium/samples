using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICustomerRepository
	{
		POCOCustomer Create(ApiCustomerModel model);

		void Update(int customerID,
		            ApiCustomerModel model);

		void Delete(int customerID);

		POCOCustomer Get(int customerID);

		List<POCOCustomer> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCustomer GetAccountNumber(string accountNumber);

		List<POCOCustomer> GetTerritoryID(Nullable<int> territoryID);
	}
}

/*<Codenesium>
    <Hash>c3c06e62b5e81b65b25a90fe021ccd3e</Hash>
</Codenesium>*/