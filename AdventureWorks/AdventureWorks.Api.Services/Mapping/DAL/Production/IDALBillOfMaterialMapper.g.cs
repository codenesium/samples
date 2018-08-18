using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALBillOfMaterialMapper
	{
		BillOfMaterial MapBOToEF(
			BOBillOfMaterial bo);

		BOBillOfMaterial MapEFToBO(
			BillOfMaterial efBillOfMaterial);

		List<BOBillOfMaterial> MapEFToBO(
			List<BillOfMaterial> records);
	}
}

/*<Codenesium>
    <Hash>2c2533e48ee18096bb8b2f2f5eea9243</Hash>
</Codenesium>*/