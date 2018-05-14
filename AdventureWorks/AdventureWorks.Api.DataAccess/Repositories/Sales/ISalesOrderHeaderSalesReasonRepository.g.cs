using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesOrderHeaderSalesReasonRepository
	{
		POCOSalesOrderHeaderSalesReason Create(ApiSalesOrderHeaderSalesReasonModel model);

		void Update(int salesOrderID,
		            ApiSalesOrderHeaderSalesReasonModel model);

		void Delete(int salesOrderID);

		POCOSalesOrderHeaderSalesReason Get(int salesOrderID);

		List<POCOSalesOrderHeaderSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>066b2ffbdfd5fb33b2446e33594f4158</Hash>
</Codenesium>*/