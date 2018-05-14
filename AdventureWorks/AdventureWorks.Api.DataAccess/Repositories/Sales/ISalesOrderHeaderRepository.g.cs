using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderRepository
	{
		POCOSalesOrderHeader Create(ApiSalesOrderHeaderModel model);

		void Update(int salesOrderID,
		            ApiSalesOrderHeaderModel model);

		void Delete(int salesOrderID);

		POCOSalesOrderHeader Get(int salesOrderID);

		List<POCOSalesOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOSalesOrderHeader GetSalesOrderNumber(string salesOrderNumber);

		List<POCOSalesOrderHeader> GetCustomerID(int customerID);
		List<POCOSalesOrderHeader> GetSalesPersonID(Nullable<int> salesPersonID);
	}
}

/*<Codenesium>
    <Hash>84958eb64b84aca002961a1e4bc61f75</Hash>
</Codenesium>*/