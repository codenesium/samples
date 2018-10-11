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
				bo.ScheduledStartDate);
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
				ef.ScheduledStartDate);
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
    <Hash>07321db9e288fa237521bb115b0b0586</Hash>
</Codenesium>*/