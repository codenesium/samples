using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>7e0e0f67760c6ece98f6359916f824c4</Hash>
</Codenesium>*/