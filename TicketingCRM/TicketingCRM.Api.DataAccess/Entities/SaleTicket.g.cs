using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("SaleTickets", Schema="dbo")]
	public partial class SaleTicket : AbstractEntity
	{
		public SaleTicket()
		{
		}

		public virtual void SetProperties(
			int id,
			int saleId,
			int ticketId)
		{
			this.Id = id;
			this.SaleId = saleId;
			this.TicketId = ticketId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("saleId")]
		public virtual int SaleId { get; private set; }

		[Column("ticketId")]
		public virtual int TicketId { get; private set; }

		[ForeignKey("SaleId")]
		public virtual Sale SaleNavigation { get; private set; }

		public void SetSaleNavigation(Sale item)
		{
			this.SaleNavigation = item;
		}

		[ForeignKey("TicketId")]
		public virtual Ticket TicketNavigation { get; private set; }

		public void SetTicketNavigation(Ticket item)
		{
			this.TicketNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>58f2a2d184920edbb7490162e7516004</Hash>
</Codenesium>*/