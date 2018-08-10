using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALBusinessEntityAddressMapper
	{
		BusinessEntityAddress MapBOToEF(
			BOBusinessEntityAddress bo);

		BOBusinessEntityAddress MapEFToBO(
			BusinessEntityAddress efBusinessEntityAddress);

		List<BOBusinessEntityAddress> MapEFToBO(
			List<BusinessEntityAddress> records);
	}
}

/*<Codenesium>
    <Hash>fce03046e7f4b1d0a7ef2f1cf1027492</Hash>
</Codenesium>*/