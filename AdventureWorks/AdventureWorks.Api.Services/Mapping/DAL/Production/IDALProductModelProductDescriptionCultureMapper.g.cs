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
    <Hash>4a2a857cd13c334fc7085a786b3324a9</Hash>
</Codenesium>*/