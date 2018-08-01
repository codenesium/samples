using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALAddressMapper
	{
		Address MapBOToEF(
			BOAddress bo);

		BOAddress MapEFToBO(
			Address efAddress);

		List<BOAddress> MapEFToBO(
			List<Address> records);
	}
}

/*<Codenesium>
    <Hash>2f7f1fbf39e16a992e9c4e7b7a803b6e</Hash>
</Codenesium>*/