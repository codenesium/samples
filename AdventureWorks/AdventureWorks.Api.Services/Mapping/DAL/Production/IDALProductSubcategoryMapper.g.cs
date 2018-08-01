using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductSubcategoryMapper
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
    <Hash>13bb1cce6b681a4443d5ea1b7a08be7f</Hash>
</Codenesium>*/