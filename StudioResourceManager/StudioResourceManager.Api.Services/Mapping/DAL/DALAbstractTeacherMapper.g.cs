using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractTeacherMapper
	{
		public virtual Teacher MapBOToEF(
			BOTeacher bo)
		{
			Teacher efTeacher = new Teacher();
			efTeacher.SetProperties(
				bo.Birthday,
				bo.Email,
				bo.FirstName,
				bo.Id,
				bo.LastName,
				bo.Phone,
				bo.UserId);
			return efTeacher;
		}

		public virtual BOTeacher MapEFToBO(
			Teacher ef)
		{
			var bo = new BOTeacher();

			bo.SetProperties(
				ef.Id,
				ef.Birthday,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Phone,
				ef.UserId);
			return bo;
		}

		public virtual List<BOTeacher> MapEFToBO(
			List<Teacher> records)
		{
			List<BOTeacher> response = new List<BOTeacher>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d9d6a8266f4d1c9c61642da9de9ff63a</Hash>
</Codenesium>*/