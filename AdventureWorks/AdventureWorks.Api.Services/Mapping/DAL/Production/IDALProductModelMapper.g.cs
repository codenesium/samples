using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductModelMapper
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
    <Hash>f004916ad26ed7ffd615bdaacc85e557</Hash>
</Codenesium>*/