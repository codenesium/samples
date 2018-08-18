using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALSaleMapper
	{
		Sale MapBOToEF(
			BOSale bo);

		BOSale MapEFToBO(
			Sale efSale);

		List<BOSale> MapEFToBO(
			List<Sale> records);
	}
}

/*<Codenesium>
    <Hash>dff40b3d1cdd565d11b8702be6041fd0</Hash>
</Codenesium>*/