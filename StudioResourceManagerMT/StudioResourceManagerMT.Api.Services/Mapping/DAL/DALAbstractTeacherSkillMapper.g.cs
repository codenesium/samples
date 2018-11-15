using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>aefa3387319aaecb635088a14ba53f24</Hash>
</Codenesium>*/