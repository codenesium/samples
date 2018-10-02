using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractEventTeacherMapper
	{
		public virtual EventTeacher MapBOToEF(
			BOEventTeacher bo)
		{
			EventTeacher efEventTeacher = new EventTeacher();
			efEventTeacher.SetProperties(
				bo.EventId,
				bo.Id);
			return efEventTeacher;
		}

		public virtual BOEventTeacher MapEFToBO(
			EventTeacher ef)
		{
			var bo = new BOEventTeacher();

			bo.SetProperties(
				ef.Id,
				ef.EventId);
			return bo;
		}

		public virtual List<BOEventTeacher> MapEFToBO(
			List<EventTeacher> records)
		{
			List<BOEventTeacher> response = new List<BOEventTeacher>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>170613ed9e0b4026bf1a786568d0b290</Hash>
</Codenesium>*/