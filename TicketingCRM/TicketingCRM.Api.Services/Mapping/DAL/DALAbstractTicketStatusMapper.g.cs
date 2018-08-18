using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractTicketStatusMapper
	{
		public virtual TicketStatus MapBOToEF(
			BOTicketStatus bo)
		{
			TicketStatus efTicketStatus = new TicketStatus();
			efTicketStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efTicketStatus;
		}

		public virtual BOTicketStatus MapEFToBO(
			TicketStatus ef)
		{
			var bo = new BOTicketStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOTicketStatus> MapEFToBO(
			List<TicketStatus> records)
		{
			List<BOTicketStatus> response = new List<BOTicketStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3fc871bb6acdb1bab3b674ce644f982d</Hash>
</Codenesium>*/