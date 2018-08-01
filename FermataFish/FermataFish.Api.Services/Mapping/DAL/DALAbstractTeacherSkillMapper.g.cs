using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractTeacherSkillMapper
	{
		public virtual TeacherSkill MapBOToEF(
			BOTeacherSkill bo)
		{
			TeacherSkill efTeacherSkill = new TeacherSkill();
			efTeacherSkill.SetProperties(
				bo.Id,
				bo.Name,
				bo.StudioId);
			return efTeacherSkill;
		}

		public virtual BOTeacherSkill MapEFToBO(
			TeacherSkill ef)
		{
			var bo = new BOTeacherSkill();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.StudioId);
			return bo;
		}

		public virtual List<BOTeacherSkill> MapEFToBO(
			List<TeacherSkill> records)
		{
			List<BOTeacherSkill> response = new List<BOTeacherSkill>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4d60285cd5b80772c8b81abbca675ed0</Hash>
</Codenesium>*/