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
    <Hash>5ac608a8d67a720da75defc44b4e8d55</Hash>
</Codenesium>*/