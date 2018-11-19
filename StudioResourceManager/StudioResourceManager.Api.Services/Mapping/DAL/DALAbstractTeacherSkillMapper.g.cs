using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractTeacherSkillMapper
	{
		public virtual TeacherSkill MapBOToEF(
			BOTeacherSkill bo)
		{
			TeacherSkill efTeacherSkill = new TeacherSkill();
			efTeacherSkill.SetProperties(
				bo.Id,
				bo.Name);
			return efTeacherSkill;
		}

		public virtual BOTeacherSkill MapEFToBO(
			TeacherSkill ef)
		{
			var bo = new BOTeacherSkill();

			bo.SetProperties(
				ef.Id,
				ef.Name);
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
    <Hash>7cbd55776e0eaf14497041f7d6bfb7df</Hash>
</Codenesium>*/