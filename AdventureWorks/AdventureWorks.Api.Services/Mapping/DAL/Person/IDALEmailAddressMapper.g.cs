using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALEmailAddressMapper
	{
		EmailAddress MapBOToEF(
			BOEmailAddress bo);

		BOEmailAddress MapEFToBO(
			EmailAddress efEmailAddress);

		List<BOEmailAddress> MapEFToBO(
			List<EmailAddress> records);
	}
}

/*<Codenesium>
    <Hash>d81ba09a33716eb1cd345b5a4d1eaec8</Hash>
</Codenesium>*/