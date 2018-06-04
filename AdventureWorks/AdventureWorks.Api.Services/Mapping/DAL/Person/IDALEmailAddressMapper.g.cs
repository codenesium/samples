using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALEmailAddressMapper
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
    <Hash>7320adcef140ab6e5e90a056845e2760</Hash>
</Codenesium>*/