using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractTicketMapper
	{
		public virtual Ticket MapBOToEF(
			BOTicket bo)
		{
			Ticket efTicket = new Ticket();
			efTicket.SetProperties(
				bo.Id,
				bo.PublicId,
				bo.TicketStatusId);
			return efTicket;
		}

		public virtual BOTicket MapEFToBO(
			Ticket ef)
		{
			var bo = new BOTicket();

			bo.SetProperties(
				ef.Id,
				ef.PublicId,
				ef.TicketStatusId);
			return bo;
		}

		public virtual List<BOTicket> MapEFToBO(
			List<Ticket> records)
		{
			List<BOTicket> response = new List<BOTicket>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2b1f39e3122c4635aadde217001e6123</Hash>
</Codenesium>*/