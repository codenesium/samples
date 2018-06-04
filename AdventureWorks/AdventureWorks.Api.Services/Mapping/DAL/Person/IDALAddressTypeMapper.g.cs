using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>f608efedf8703218b410ee2a870a470f</Hash>
</Codenesium>*/