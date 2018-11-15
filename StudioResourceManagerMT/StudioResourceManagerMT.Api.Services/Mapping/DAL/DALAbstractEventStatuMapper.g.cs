using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class DALAbstractEventStatuMapper
	{
		public virtual EventStatu MapBOToEF(
			BOEventStatu bo)
		{
			EventStatu efEventStatu = new EventStatu();
			efEventStatu.SetProperties(
				bo.Id,
				bo.Name);
			return efEventStatu;
		}

		public virtual BOEventStatu MapEFToBO(
			EventStatu ef)
		{
			var bo = new BOEventStatu();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOEventStatu> MapEFToBO(
			List<EventStatu> records)
		{
			List<BOEventStatu> response = new List<BOEventStatu>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>78050a39558c4b6f812c2409e30c9a4f</Hash>
</Codenesium>*/