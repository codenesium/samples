using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public interface IDALSaleMapper
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
    <Hash>b64e7d580d4d9e06fd4860f51a6c74a1</Hash>
</Codenesium>*/