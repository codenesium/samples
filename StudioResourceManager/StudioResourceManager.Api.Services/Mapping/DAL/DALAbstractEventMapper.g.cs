using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractEventMapper
	{
		public virtual Event MapBOToEF(
			BOEvent bo)
		{
			Event efEvent = new Event();
			efEvent.SetProperties(
				bo.ActualEndDate,
				bo.ActualStartDate,
				bo.BillAmount,
				bo.EventStatusId,
				bo.Id,
				bo.ScheduledEndDate,
				bo.ScheduledStartDate,
				bo.StudentNote,
				bo.TeacherNote,
				bo.IsDeleted);
			return efEvent;
		}

		public virtual BOEvent MapEFToBO(
			Event ef)
		{
			var bo = new BOEvent();

			bo.SetProperties(
				ef.Id,
				ef.ActualEndDate,
				ef.ActualStartDate,
				ef.BillAmount,
				ef.EventStatusId,
				ef.ScheduledEndDate,
				ef.ScheduledStartDate,
				ef.StudentNote,
				ef.TeacherNote,
				ef.IsDeleted);
			return bo;
		}

		public virtual List<BOEvent> MapEFToBO(
			List<Event> records)
		{
			List<BOEvent> response = new List<BOEvent>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9148c1c52f063e0903bff005c0552f80</Hash>
</Codenesium>*/