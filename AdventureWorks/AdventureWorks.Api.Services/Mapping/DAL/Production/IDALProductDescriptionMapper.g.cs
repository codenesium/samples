using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>3939f847d4fd7e3802aab2637c2068fb</Hash>
</Codenesium>*/