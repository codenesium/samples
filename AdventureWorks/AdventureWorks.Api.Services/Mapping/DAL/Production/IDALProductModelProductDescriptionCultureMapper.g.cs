using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductModelProductDescriptionCultureMapper
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
    <Hash>c4747b0b7d3b6d9b903b1e9748094733</Hash>
</Codenesium>*/