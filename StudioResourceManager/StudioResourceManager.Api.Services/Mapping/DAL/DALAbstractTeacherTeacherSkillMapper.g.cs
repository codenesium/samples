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
				bo.TeacherSkillId,
				bo.IsDeleted);
			return efTeacherTeacherSkill;
		}

		public virtual BOTeacherTeacherSkill MapEFToBO(
			TeacherTeacherSkill ef)
		{
			var bo = new BOTeacherTeacherSkill();

			bo.SetProperties(
				ef.TeacherId,
				ef.TeacherSkillId,
				ef.IsDeleted);
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
    <Hash>705ce2f049554717024cbff8df1054c9</Hash>
</Codenesium>*/