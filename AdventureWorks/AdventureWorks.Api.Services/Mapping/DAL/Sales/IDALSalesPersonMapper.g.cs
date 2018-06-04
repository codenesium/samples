using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALSalesPersonMapper
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
    <Hash>789748f7139cf306661e2cec88e39ea3</Hash>
</Codenesium>*/