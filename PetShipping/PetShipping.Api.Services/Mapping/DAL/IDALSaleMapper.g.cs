using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>779409f390a6611af6c990675addbb31</Hash>
</Codenesium>*/