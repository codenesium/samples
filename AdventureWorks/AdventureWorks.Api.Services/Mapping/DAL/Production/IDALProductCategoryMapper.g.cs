using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductCategoryMapper
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
    <Hash>2981f3508219be8210daf3c1dd23d096</Hash>
</Codenesium>*/