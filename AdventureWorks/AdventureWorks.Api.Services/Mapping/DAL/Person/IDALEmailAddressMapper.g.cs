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
    <Hash>42e0390884c3b8f7f5b349c607f8117e</Hash>
</Codenesium>*/