using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderRepository
	{
		Task<DTOSalesOrderHeader> Create(DTOSalesOrderHeader dto);

		Task Update(int salesOrderID,
		            DTOSalesOrderHeader dto);

		Task Delete(int salesOrderID);

		Task<DTOSalesOrderHeader> Get(int salesOrderID);

		Task<List<DTOSalesOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOSalesOrderHeader> GetSalesOrderNumber(string salesOrderNumber);
		Task<List<DTOSalesOrderHeader>> GetCustomerID(int customerID);
		Task<List<DTOSalesOrderHeader>> GetSalesPersonID(Nullable<int> salesPersonID);
	}
}

/*<Codenesium>
    <Hash>5472f120a840d65a52465aa05c74f8d6</Hash>
</Codenesium>*/