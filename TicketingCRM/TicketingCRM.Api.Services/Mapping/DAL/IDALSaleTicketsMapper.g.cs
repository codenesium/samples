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
    <Hash>473af497e92b89d130ec50fa03bad808</Hash>
</Codenesium>*/