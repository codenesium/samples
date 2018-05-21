using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderRepository
	{
		Task<POCOSalesOrderHeader> Create(ApiSalesOrderHeaderModel model);

		Task Update(int salesOrderID,
		            ApiSalesOrderHeaderModel model);

		Task Delete(int salesOrderID);

		Task<POCOSalesOrderHeader> Get(int salesOrderID);

		Task<List<POCOSalesOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOSalesOrderHeader> GetSalesOrderNumber(string salesOrderNumber);
		Task<List<POCOSalesOrderHeader>> GetCustomerID(int customerID);
		Task<List<POCOSalesOrderHeader>> GetSalesPersonID(Nullable<int> salesPersonID);
	}
}

/*<Codenesium>
    <Hash>3f694370cbb4b667773df2ebe33d5311</Hash>
</Codenesium>*/