using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractBOTicket : AbstractBusinessObject
	{
		public AbstractBOTicket()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string publicId,
		                                  int ticketStatusId)
		{
			this.Id = id;
			this.PublicId = publicId;
			this.TicketStatusId = ticketStatusId;
		}

		public int Id { get; private set; }

		public string PublicId { get; private set; }

		public int TicketStatusId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5dac54e7c540398a1de3d338117c892d</Hash>
</Codenesium>*/