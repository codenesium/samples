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
    <Hash>fd335ea26097ee492a9cb997c2bd0631</Hash>
</Codenesium>*/