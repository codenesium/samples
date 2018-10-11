using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractTeacherTeacherSkillMapper
	{
		public virtual TeacherTeacherSkill MapBOToEF(
			BOTeacherTeacherSkill bo)
		{
			TeacherTeacherSkill efTeacherTeacherSkill = new TeacherTeacherSkill();
			efTeacherTeacherSkill.SetProperties(
				bo.TeacherId,
				bo.TeacherSkillId);
			return efTeacherTeacherSkill;
		}

		public virtual BOTeacherTeacherSkill MapEFToBO(
			TeacherTeacherSkill ef)
		{
			var bo = new BOTeacherTeacherSkill();

			bo.SetProperties(
				ef.TeacherId,
				ef.TeacherSkillId);
			return bo;
		}

		public virtual List<BOTeacherTeacherSkill> MapEFToBO(
			List<TeacherTeacherSkill> records)
		{
			List<BOTeacherTeacherSkill> response = new List<BOTeacherTeacherSkill>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>110d59b520be8bb12a1f82c69c5d2f10</Hash>
</Codenesium>*/