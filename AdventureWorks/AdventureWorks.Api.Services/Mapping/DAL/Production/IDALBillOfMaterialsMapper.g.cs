using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALBillOfMaterialsMapper
	{
		BillOfMaterials MapBOToEF(
			BOBillOfMaterials bo);

		BOBillOfMaterials MapEFToBO(
			BillOfMaterials efBillOfMaterials);

		List<BOBillOfMaterials> MapEFToBO(
			List<BillOfMaterials> records);
	}
}

/*<Codenesium>
    <Hash>acf2212bb49711af128844a926469ec7</Hash>
</Codenesium>*/