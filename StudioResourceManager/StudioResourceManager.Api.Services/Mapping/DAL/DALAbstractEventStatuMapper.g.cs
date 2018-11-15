using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>847defe7b5e2507d63ca31f00a96d43d</Hash>
</Codenesium>*/