using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesOrderHeader
	{
		Task<CreateResponse<POCOSalesOrderHeader>> Create(
			ApiSalesOrderHeaderModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            ApiSalesOrderHeaderModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		Task<POCOSalesOrderHeader> Get(int salesOrderID);

		Task<List<POCOSalesOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOSalesOrderHeader> GetSalesOrderNumber(string salesOrderNumber);
		Task<List<POCOSalesOrderHeader>> GetCustomerID(int customerID);
		Task<List<POCOSalesOrderHeader>> GetSalesPersonID(Nullable<int> salesPersonID);
	}
}

/*<Codenesium>
    <Hash>0f9ffdbc45b5e68112eaca49b9f8259f</Hash>
</Codenesium>*/