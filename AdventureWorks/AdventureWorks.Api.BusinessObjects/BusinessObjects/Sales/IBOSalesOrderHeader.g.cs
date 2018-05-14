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

		POCOSalesOrderHeader Get(int salesOrderID);

		List<POCOSalesOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOSalesOrderHeader GetSalesOrderNumber(string salesOrderNumber);

		List<POCOSalesOrderHeader> GetCustomerID(int customerID);
		List<POCOSalesOrderHeader> GetSalesPersonID(Nullable<int> salesPersonID);
	}
}

/*<Codenesium>
    <Hash>f209b6175d2e0f1ffcd3d0ce1dbe3bc0</Hash>
</Codenesium>*/