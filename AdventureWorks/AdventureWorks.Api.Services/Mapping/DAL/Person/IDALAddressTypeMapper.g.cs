using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALAddressTypeMapper
	{
		AddressType MapBOToEF(
			BOAddressType bo);

		BOAddressType MapEFToBO(
			AddressType efAddressType);

		List<BOAddressType> MapEFToBO(
			List<AddressType> records);
	}
}

/*<Codenesium>
    <Hash>d47520c2aed1abcddb5aee0bb65f4278</Hash>
</Codenesium>*/