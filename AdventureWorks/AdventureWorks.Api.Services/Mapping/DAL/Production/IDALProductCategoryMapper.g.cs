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
    <Hash>53b7e5d8d58b9d64054f8f96cd6214c9</Hash>
</Codenesium>*/