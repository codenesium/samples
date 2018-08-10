using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPurchaseOrderDetailMapper
	{
		PurchaseOrderDetail MapBOToEF(
			BOPurchaseOrderDetail bo);

		BOPurchaseOrderDetail MapEFToBO(
			PurchaseOrderDetail efPurchaseOrderDetail);

		List<BOPurchaseOrderDetail> MapEFToBO(
			List<PurchaseOrderDetail> records);
	}
}

/*<Codenesium>
    <Hash>fed0914183540748fba97275e234c59e</Hash>
</Codenesium>*/