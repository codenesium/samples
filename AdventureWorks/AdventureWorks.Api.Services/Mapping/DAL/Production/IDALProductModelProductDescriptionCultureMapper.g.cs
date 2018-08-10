using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductModelProductDescriptionCultureMapper
	{
		ProductModelProductDescriptionCulture MapBOToEF(
			BOProductModelProductDescriptionCulture bo);

		BOProductModelProductDescriptionCulture MapEFToBO(
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture);

		List<BOProductModelProductDescriptionCulture> MapEFToBO(
			List<ProductModelProductDescriptionCulture> records);
	}
}

/*<Codenesium>
    <Hash>dc137c436e69dddc963814b133622088</Hash>
</Codenesium>*/