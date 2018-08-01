using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductProductPhotoMapper
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
    <Hash>86cadfec8f5ec383413e425ab5d012c5</Hash>
</Codenesium>*/