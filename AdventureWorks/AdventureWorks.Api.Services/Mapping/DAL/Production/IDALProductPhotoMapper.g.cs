using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductPhotoMapper
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
    <Hash>9b0818d06965a07913f4337b2fc7a247</Hash>
</Codenesium>*/