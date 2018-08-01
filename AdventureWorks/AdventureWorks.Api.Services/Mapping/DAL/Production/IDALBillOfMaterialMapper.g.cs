using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALBillOfMaterialMapper
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
    <Hash>8c842b7eb42e38b43e4900ecea9d6533</Hash>
</Codenesium>*/