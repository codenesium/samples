using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesPersonMapper
	{
		SalesPerson MapBOToEF(
			BOSalesPerson bo);

		BOSalesPerson MapEFToBO(
			SalesPerson efSalesPerson);

		List<BOSalesPerson> MapEFToBO(
			List<SalesPerson> records);
	}
}

/*<Codenesium>
    <Hash>1cb8c98e976a7ff937feed5628a6f7b8</Hash>
</Codenesium>*/