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
    <Hash>16f054f211acffb6b62f5392de0afe70</Hash>
</Codenesium>*/