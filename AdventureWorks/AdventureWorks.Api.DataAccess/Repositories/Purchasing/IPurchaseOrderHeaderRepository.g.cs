using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderHeaderRepository
	{
		int Create(PurchaseOrderHeaderModel model);

		void Update(int purchaseOrderID,
		            PurchaseOrderHeaderModel model);

		void Delete(int purchaseOrderID);

		POCOPurchaseOrderHeader Get(int purchaseOrderID);

		List<POCOPurchaseOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ffcf558dadeaf6b32df834dcfb986dbb</Hash>
</Codenesium>*/