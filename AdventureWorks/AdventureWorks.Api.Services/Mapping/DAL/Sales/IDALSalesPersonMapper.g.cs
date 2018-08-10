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
    <Hash>627d9bfc01e56ce2f2c082c7a8541880</Hash>
</Codenesium>*/