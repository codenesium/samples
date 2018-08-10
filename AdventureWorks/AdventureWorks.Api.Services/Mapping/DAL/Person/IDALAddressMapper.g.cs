using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALAddressMapper
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
    <Hash>f7db98178a38c7d439ac9f066a9a57e5</Hash>
</Codenesium>*/