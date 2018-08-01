using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>2279a78af5b16251ca0ca4121cad30cb</Hash>
</Codenesium>*/