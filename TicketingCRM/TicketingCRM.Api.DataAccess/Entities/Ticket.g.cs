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
		public virtual int Id { get; private set; }

		[MaxLength(8)]
		[Column("publicId")]
		public virtual string PublicId { get; private set; }

		[Column("ticketStatusId")]
		public virtual int TicketStatusId { get; private set; }

		[ForeignKey("TicketStatusId")]
		public virtual TicketStatu TicketStatuNavigation { get; private set; }

		public void SetTicketStatuNavigation(TicketStatu item)
		{
			this.TicketStatuNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>d8e125c3c5c5aef0c6687e17fad96b87</Hash>
</Codenesium>*/