using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductProductPhotoMapper
	{
		ProductProductPhoto MapBOToEF(
			BOProductProductPhoto bo);

		BOProductProductPhoto MapEFToBO(
			ProductProductPhoto efProductProductPhoto);

		List<BOProductProductPhoto> MapEFToBO(
			List<ProductProductPhoto> records);
	}
}

/*<Codenesium>
    <Hash>fa2d97c45023a1a7420057f7927f9628</Hash>
</Codenesium>*/