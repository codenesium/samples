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
				bo.Id,
				bo.TeacherId,
				bo.TeacherSkillId);
			return efTeacherTeacherSkill;
		}

		public virtual BOTeacherTeacherSkill MapEFToBO(
			TeacherTeacherSkill ef)
		{
			var bo = new BOTeacherTeacherSkill();

			bo.SetProperties(
				ef.Id,
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
    <Hash>7558c39c282b8c601045aaf49c73bf4b</Hash>
</Codenesium>*/