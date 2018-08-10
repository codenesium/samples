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
    <Hash>55145b77eeeb13778e993f814ee6c8a0</Hash>
</Codenesium>*/