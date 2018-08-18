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
    <Hash>98b226eba3f5294f09052c63effa68d9</Hash>
</Codenesium>*/