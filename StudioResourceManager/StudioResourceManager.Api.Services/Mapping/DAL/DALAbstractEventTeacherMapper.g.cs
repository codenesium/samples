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
				bo.TeacherId);
			return efEventTeacher;
		}

		public virtual BOEventTeacher MapEFToBO(
			EventTeacher ef)
		{
			var bo = new BOEventTeacher();

			bo.SetProperties(
				ef.EventId,
				ef.TeacherId);
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
    <Hash>7ec889baca6b24b8a10ebcaefd090f54</Hash>
</Codenesium>*/