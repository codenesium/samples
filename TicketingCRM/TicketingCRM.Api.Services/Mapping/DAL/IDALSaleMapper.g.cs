using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
    <Hash>c7236a69ffb118d5c17fad456873bbb0</Hash>
</Codenesium>*/