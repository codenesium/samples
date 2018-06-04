using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALPurchaseOrderDetailMapper
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
    <Hash>c5796d9a2da084065ace292a54071d18</Hash>
</Codenesium>*/