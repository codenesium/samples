using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class DALAbstractTeacherXTeacherSkillMapper
	{
		public virtual TeacherXTeacherSkill MapBOToEF(
			BOTeacherXTeacherSkill bo)
		{
			TeacherXTeacherSkill efTeacherXTeacherSkill = new TeacherXTeacherSkill();
			efTeacherXTeacherSkill.SetProperties(
				bo.Id,
				bo.TeacherId,
				bo.TeacherSkillId,
				bo.StudioId);
			return efTeacherXTeacherSkill;
		}

		public virtual BOTeacherXTeacherSkill MapEFToBO(
			TeacherXTeacherSkill ef)
		{
			var bo = new BOTeacherXTeacherSkill();

			bo.SetProperties(
				ef.Id,
				ef.TeacherId,
				ef.TeacherSkillId,
				ef.StudioId);
			return bo;
		}

		public virtual List<BOTeacherXTeacherSkill> MapEFToBO(
			List<TeacherXTeacherSkill> records)
		{
			List<BOTeacherXTeacherSkill> response = new List<BOTeacherXTeacherSkill>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1ca9e9d13ee9fb3ff7432ffe42ded31b</Hash>
</Codenesium>*/