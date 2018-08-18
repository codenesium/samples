using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCultureMapper
	{
		Culture MapBOToEF(
			BOCulture bo);

		BOCulture MapEFToBO(
			Culture efCulture);

		List<BOCulture> MapEFToBO(
			List<Culture> records);
	}
}

/*<Codenesium>
    <Hash>d2c57f8ac8404b2b6d0500b8b7603dfb</Hash>
</Codenesium>*/