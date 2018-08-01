using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALSaleTicketsMapper
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
    <Hash>b47870f2d09dca7e5a8afecb8645677c</Hash>
</Codenesium>*/