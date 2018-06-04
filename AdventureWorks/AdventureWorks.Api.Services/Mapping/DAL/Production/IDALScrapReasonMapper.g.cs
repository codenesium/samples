using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>b99086bd42512d081125a889ab5bd4de</Hash>
</Codenesium>*/