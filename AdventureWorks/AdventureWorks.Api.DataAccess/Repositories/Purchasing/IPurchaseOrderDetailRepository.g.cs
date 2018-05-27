using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPurchaseOrderDetailRepository
	{
		Task<DTOPurchaseOrderDetail> Create(DTOPurchaseOrderDetail dto);

		Task Update(int purchaseOrderID,
		            DTOPurchaseOrderDetail dto);

		Task Delete(int purchaseOrderID);

		Task<DTOPurchaseOrderDetail> Get(int purchaseOrderID);

		Task<List<DTOPurchaseOrderDetail>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOPurchaseOrderDetail>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>feee6fb2affc1f9ed64efc3486fd0efc</Hash>
</Codenesium>*/