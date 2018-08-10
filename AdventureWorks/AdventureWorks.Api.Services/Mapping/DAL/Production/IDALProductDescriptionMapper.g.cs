using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductDescriptionMapper
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
    <Hash>70c5c8297de77f615fcd963417ae385d</Hash>
</Codenesium>*/