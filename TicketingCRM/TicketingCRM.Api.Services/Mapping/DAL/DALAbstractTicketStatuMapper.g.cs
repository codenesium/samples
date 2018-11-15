using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class DALAbstractTicketStatuMapper
	{
		public virtual TicketStatu MapBOToEF(
			BOTicketStatu bo)
		{
			TicketStatu efTicketStatu = new TicketStatu();
			efTicketStatu.SetProperties(
				bo.Id,
				bo.Name);
			return efTicketStatu;
		}

		public virtual BOTicketStatu MapEFToBO(
			TicketStatu ef)
		{
			var bo = new BOTicketStatu();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOTicketStatu> MapEFToBO(
			List<TicketStatu> records)
		{
			List<BOTicketStatu> response = new List<BOTicketStatu>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d9b316f959aefd04f435c9bb2e7ee6c4</Hash>
</Codenesium>*/