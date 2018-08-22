using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractTeacherMapper
	{
		public virtual Teacher MapBOToEF(
			BOTeacher bo)
		{
			Teacher efTeacher = new Teacher();
			efTeacher.SetProperties(
				bo.Id,
				bo.Birthday,
				bo.Email,
				bo.FirstName,
				bo.LastName,
				bo.Phone,
				bo.StudioId);
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
				ef.StudioId);
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
    <Hash>ccf4500580132718127c8065d803aa80</Hash>
</Codenesium>*/