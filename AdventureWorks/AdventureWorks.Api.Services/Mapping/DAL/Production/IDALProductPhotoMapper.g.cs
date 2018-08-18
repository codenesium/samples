using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductPhotoMapper
	{
		ProductPhoto MapBOToEF(
			BOProductPhoto bo);

		BOProductPhoto MapEFToBO(
			ProductPhoto efProductPhoto);

		List<BOProductPhoto> MapEFToBO(
			List<ProductPhoto> records);
	}
}

/*<Codenesium>
    <Hash>f57872563e552346feb4bc7a52acf4bd</Hash>
</Codenesium>*/