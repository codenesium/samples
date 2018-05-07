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

		POCOCustomer Get(int customerID);

		List<POCOCustomer> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ae08e85333c2461e0646b16a240cc27c</Hash>
</Codenesium>*/