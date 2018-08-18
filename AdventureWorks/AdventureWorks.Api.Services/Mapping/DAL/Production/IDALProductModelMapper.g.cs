using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductModelMapper
	{
		ProductModel MapBOToEF(
			BOProductModel bo);

		BOProductModel MapEFToBO(
			ProductModel efProductModel);

		List<BOProductModel> MapEFToBO(
			List<ProductModel> records);
	}
}

/*<Codenesium>
    <Hash>58c143c52e9b13db3578942c32f5fa52</Hash>
</Codenesium>*/