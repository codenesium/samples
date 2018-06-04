using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>429d0aa42514b0c1bb5a980134f60a1c</Hash>
</Codenesium>*/