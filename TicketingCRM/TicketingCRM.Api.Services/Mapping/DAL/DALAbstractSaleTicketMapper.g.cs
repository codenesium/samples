using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractSaleTicketMapper
	{
		public virtual SaleTicket MapBOToEF(
			BOSaleTicket bo)
		{
			SaleTicket efSaleTicket = new SaleTicket();
			efSaleTicket.SetProperties(
				bo.Id,
				bo.SaleId,
				bo.TicketId);
			return efSaleTicket;
		}

		public virtual BOSaleTicket MapEFToBO(
			SaleTicket ef)
		{
			var bo = new BOSaleTicket();

			bo.SetProperties(
				ef.Id,
				ef.SaleId,
				ef.TicketId);
			return bo;
		}

		public virtual List<BOSaleTicket> MapEFToBO(
			List<SaleTicket> records)
		{
			List<BOSaleTicket> response = new List<BOSaleTicket>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3578d93cce58ebfebc33e6bba8cf69cc</Hash>
</Codenesium>*/