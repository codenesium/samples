using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractVEventMapper
	{
		public virtual VEvent MapBOToEF(
			BOVEvent bo)
		{
			VEvent efVEvent = new VEvent();
			efVEvent.SetProperties(
				bo.ActualEndDate,
				bo.ActualStartDate,
				bo.BillAmount,
				bo.EventStatusId,
				bo.Id,
				bo.ScheduledEndDate,
				bo.ScheduledStartDate,
				bo.IsDeleted);
			return efVEvent;
		}

		public virtual BOVEvent MapEFToBO(
			VEvent ef)
		{
			var bo = new BOVEvent();

			bo.SetProperties(
				ef.Id,
				ef.ActualEndDate,
				ef.ActualStartDate,
				ef.BillAmount,
				ef.EventStatusId,
				ef.ScheduledEndDate,
				ef.ScheduledStartDate,
				ef.IsDeleted);
			return bo;
		}

		public virtual List<BOVEvent> MapEFToBO(
			List<VEvent> records)
		{
			List<BOVEvent> response = new List<BOVEvent>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0298058e92c8e9de81045e8d90e788c8</Hash>
</Codenesium>*/