using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderDetailRepository
	{
		POCOSalesOrderDetail Create(ApiSalesOrderDetailModel model);

		void Update(int salesOrderID,
		            ApiSalesOrderDetailModel model);

		void Delete(int salesOrderID);

		POCOSalesOrderDetail Get(int salesOrderID);

		List<POCOSalesOrderDetail> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOSalesOrderDetail> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>3b0352fa915ba94856174d4967034070</Hash>
</Codenesium>*/