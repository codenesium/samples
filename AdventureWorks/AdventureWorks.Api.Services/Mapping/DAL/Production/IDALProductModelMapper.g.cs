using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>3cbcc05c1edc8de3f4d90e31bc85d8e4</Hash>
</Codenesium>*/