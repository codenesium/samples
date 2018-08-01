using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALCultureMapper
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
    <Hash>1b93712eb8a3ea780d9966851122e239</Hash>
</Codenesium>*/