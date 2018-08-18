using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALBusinessEntityContactMapper
	{
		BusinessEntityContact MapBOToEF(
			BOBusinessEntityContact bo);

		BOBusinessEntityContact MapEFToBO(
			BusinessEntityContact efBusinessEntityContact);

		List<BOBusinessEntityContact> MapEFToBO(
			List<BusinessEntityContact> records);
	}
}

/*<Codenesium>
    <Hash>d984d6563a9d8c8e763bdf5f10b2f3d9</Hash>
</Codenesium>*/