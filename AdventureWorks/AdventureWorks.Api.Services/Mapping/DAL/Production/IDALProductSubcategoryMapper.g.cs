using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductSubcategoryMapper
	{
		ProductSubcategory MapBOToEF(
			BOProductSubcategory bo);

		BOProductSubcategory MapEFToBO(
			ProductSubcategory efProductSubcategory);

		List<BOProductSubcategory> MapEFToBO(
			List<ProductSubcategory> records);
	}
}

/*<Codenesium>
    <Hash>b6aa930fb5b3f1469b6c5ff4fc340813</Hash>
</Codenesium>*/