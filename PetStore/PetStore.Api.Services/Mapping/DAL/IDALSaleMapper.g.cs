using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
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
    <Hash>9d449e1bf8f31e858ce9bdfe4fb5c41d</Hash>
</Codenesium>*/