using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>34a91fd33ed6c768f12514a18aba655c</Hash>
</Codenesium>*/