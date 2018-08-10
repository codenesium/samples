using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALSaleTicketsMapper
	{
		SaleTickets MapBOToEF(
			BOSaleTickets bo);

		BOSaleTickets MapEFToBO(
			SaleTickets efSaleTickets);

		List<BOSaleTickets> MapEFToBO(
			List<SaleTickets> records);
	}
}

/*<Codenesium>
    <Hash>9c111cb84556e691f457c0ce133599a3</Hash>
</Codenesium>*/