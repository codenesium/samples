using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPurchaseOrderHeader
	{
		Task<CreateResponse<int>> Create(
			PurchaseOrderHeaderModel model);

		Task<ActionResponse> Update(int purchaseOrderID,
		                            PurchaseOrderHeaderModel model);

		Task<ActionResponse> Delete(int purchaseOrderID);

		POCOPurchaseOrderHeader Get(int purchaseOrderID);

		List<POCOPurchaseOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>91aab869134227e6fd3ceeaad2ab7441</Hash>
</Codenesium>*/