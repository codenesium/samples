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
    <Hash>f611becafaf3957dbdae43cfc61e2bd9</Hash>
</Codenesium>*/