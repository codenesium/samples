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
    <Hash>a93d09e0c6c5b45db865f06c9ae87653</Hash>
</Codenesium>*/