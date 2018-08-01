using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALScrapReasonMapper
	{
		ScrapReason MapBOToEF(
			BOScrapReason bo);

		BOScrapReason MapEFToBO(
			ScrapReason efScrapReason);

		List<BOScrapReason> MapEFToBO(
			List<ScrapReason> records);
	}
}

/*<Codenesium>
    <Hash>782ea1db4a06dd35c2bd0d4997bde766</Hash>
</Codenesium>*/