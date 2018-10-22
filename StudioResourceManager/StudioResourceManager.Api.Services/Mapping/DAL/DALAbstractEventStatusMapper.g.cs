using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractEventStatusMapper
	{
		public virtual EventStatus MapBOToEF(
			BOEventStatus bo)
		{
			EventStatus efEventStatus = new EventStatus();
			efEventStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efEventStatus;
		}

		public virtual BOEventStatus MapEFToBO(
			EventStatus ef)
		{
			var bo = new BOEventStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOEventStatus> MapEFToBO(
			List<EventStatus> records)
		{
			List<BOEventStatus> response = new List<BOEventStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1e5486b8c0638421835b7442d0047ddc</Hash>
</Codenesium>*/