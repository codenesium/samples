using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALSaleTicketMapper
	{
		SaleTicket MapBOToEF(
			BOSaleTicket bo);

		BOSaleTicket MapEFToBO(
			SaleTicket efSaleTicket);

		List<BOSaleTicket> MapEFToBO(
			List<SaleTicket> records);
	}
}

/*<Codenesium>
    <Hash>753a2b53def9b7cb2aa73811e1196697</Hash>
</Codenesium>*/