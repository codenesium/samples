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
		public virtual TicketStatus TicketStatusIdNavigation { get; private set; }

		public void SetTicketStatusIdNavigation(TicketStatus item)
		{
			this.TicketStatusIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>7cbfaec0ce56390ad4dbbcc411523415</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/