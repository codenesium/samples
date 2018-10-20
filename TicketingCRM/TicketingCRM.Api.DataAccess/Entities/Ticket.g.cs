using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("Ticket", Schema="dbo")]
	public partial class Ticket : AbstractEntity
	{
		public Ticket()
		{
		}

		public virtual void SetProperties(
			int id,
			string publicId,
			int ticketStatusId)
		{
			this.Id = id;
			this.PublicId = publicId;
			this.TicketStatusId = ticketStatusId;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(8)]
		[Column("publicId")]
		public string PublicId { get; private set; }

		[Column("ticketStatusId")]
		public int TicketStatusId { get; private set; }

		[ForeignKey("TicketStatusId")]
		public virtual TicketStatu TicketStatuNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3acb109e0419035432824693a0c973ef</Hash>
</Codenesium>*/