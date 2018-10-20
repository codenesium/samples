using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
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
				bo.Name,
				bo.IsDeleted);
			return efTeacherSkill;
		}

		public virtual BOTeacherSkill MapEFToBO(
			TeacherSkill ef)
		{
			var bo = new BOTeacherSkill();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.IsDeleted);
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
    <Hash>9ba9cf0f0a2f39603d730242a70b9a2a</Hash>
</Codenesium>*/