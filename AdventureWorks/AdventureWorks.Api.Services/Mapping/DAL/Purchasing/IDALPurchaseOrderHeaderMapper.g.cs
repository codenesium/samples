using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALPurchaseOrderHeaderMapper
	{
		PurchaseOrderHeader MapBOToEF(
			BOPurchaseOrderHeader bo);

		BOPurchaseOrderHeader MapEFToBO(
			PurchaseOrderHeader efPurchaseOrderHeader);

		List<BOPurchaseOrderHeader> MapEFToBO(
			List<PurchaseOrderHeader> records);
	}
}

/*<Codenesium>
    <Hash>58f6d3fb096bfe32e9f4ac08e89c8152</Hash>
</Codenesium>*/