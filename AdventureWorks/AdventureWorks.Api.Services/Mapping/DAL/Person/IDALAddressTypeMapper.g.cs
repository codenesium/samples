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
    <Hash>22bcb4f10689907430946d4b51020780</Hash>
</Codenesium>*/