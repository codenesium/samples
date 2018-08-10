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
    <Hash>4dfb2900c12f72e42c36298929fadd99</Hash>
</Codenesium>*/