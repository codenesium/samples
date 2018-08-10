using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductCategoryMapper
	{
		ProductCategory MapBOToEF(
			BOProductCategory bo);

		BOProductCategory MapEFToBO(
			ProductCategory efProductCategory);

		List<BOProductCategory> MapEFToBO(
			List<ProductCategory> records);
	}
}

/*<Codenesium>
    <Hash>59ba209ad6dbb764a3efe0189bd8d053</Hash>
</Codenesium>*/