using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>dfa29bd994b8fc1a6ac96251dd7bd314</Hash>
</Codenesium>*/