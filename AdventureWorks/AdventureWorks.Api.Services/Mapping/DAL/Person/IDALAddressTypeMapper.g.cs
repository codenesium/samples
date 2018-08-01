using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALAddressTypeMapper
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
    <Hash>79b0be0d3a54e1e194f637a8cf4068af</Hash>
</Codenesium>*/