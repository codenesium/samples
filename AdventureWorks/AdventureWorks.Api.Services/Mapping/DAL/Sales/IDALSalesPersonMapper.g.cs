using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>5c910f3a29c3f2de247fe30391ab002a</Hash>
</Codenesium>*/