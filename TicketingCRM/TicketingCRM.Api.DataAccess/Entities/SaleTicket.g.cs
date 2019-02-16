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
		public virtual Sale SaleIdNavigation { get; private set; }

		public void SetSaleIdNavigation(Sale item)
		{
			this.SaleIdNavigation = item;
		}

		[ForeignKey("TicketId")]
		public virtual Ticket TicketIdNavigation { get; private set; }

		public void SetTicketIdNavigation(Ticket item)
		{
			this.TicketIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>b69a76f2dd97860d933738f155d8d69f</Hash>
</Codenesium>*/