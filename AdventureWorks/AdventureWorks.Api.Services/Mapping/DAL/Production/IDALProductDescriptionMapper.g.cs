using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductDescriptionMapper
	{
		ProductDescription MapBOToEF(
			BOProductDescription bo);

		BOProductDescription MapEFToBO(
			ProductDescription efProductDescription);

		List<BOProductDescription> MapEFToBO(
			List<ProductDescription> records);
	}
}

/*<Codenesium>
    <Hash>4a83272845fa6c65cf7cd3e2a2987a4d</Hash>
</Codenesium>*/