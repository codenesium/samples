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

		[Column("publicId")]
		public string PublicId { get; private set; }

		[Column("ticketStatusId")]
		public int TicketStatusId { get; private set; }

		[ForeignKey("TicketStatusId")]
		public virtual TicketStatus TicketStatusNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f42e5c66e1ce1a91d03d61b1a0f63212</Hash>
</Codenesium>*/