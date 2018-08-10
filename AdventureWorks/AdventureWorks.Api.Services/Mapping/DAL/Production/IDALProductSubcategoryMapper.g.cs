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
    <Hash>2d3bcf38fa2db788a7ec32f893e41df5</Hash>
</Codenesium>*/