using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractBOSaleTicket : AbstractBusinessObject
	{
		public AbstractBOSaleTicket()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int saleId,
		                                  int ticketId)
		{
			this.Id = id;
			this.SaleId = saleId;
			this.TicketId = ticketId;
		}

		public int Id { get; private set; }

		public int SaleId { get; private set; }

		public int TicketId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1209bea96ce0ed07be368b7da4f07b4a</Hash>
</Codenesium>*/