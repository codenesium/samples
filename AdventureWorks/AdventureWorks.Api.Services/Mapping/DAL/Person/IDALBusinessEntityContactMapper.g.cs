using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALBusinessEntityContactMapper
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
    <Hash>000e9f25f02916adc25b6d590ea3fe97</Hash>
</Codenesium>*/