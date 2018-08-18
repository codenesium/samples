using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractBOSaleTickets : AbstractBusinessObject
	{
		public AbstractBOSaleTickets()
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
    <Hash>a2d4fabf295b406f816e9254eb75aada</Hash>
</Codenesium>*/