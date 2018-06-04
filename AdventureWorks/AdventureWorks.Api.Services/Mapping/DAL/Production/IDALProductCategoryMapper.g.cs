using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>64eeb3b83e51bd6a5e3314631c5ec1a5</Hash>
</Codenesium>*/