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
		Task<CreateResponse<int>> Create(
			SalesOrderHeaderModel model);

		Task<ActionResponse> Update(int salesOrderID,
		                            SalesOrderHeaderModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		POCOSalesOrderHeader Get(int salesOrderID);

		List<POCOSalesOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d2082fa142a642a7b38b72ac0ba29f6a</Hash>
</Codenesium>*/