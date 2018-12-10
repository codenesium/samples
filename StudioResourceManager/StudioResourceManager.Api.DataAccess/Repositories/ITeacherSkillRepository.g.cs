using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface ITeacherSkillRepository
	{
		Task<TeacherSkill> Create(TeacherSkill item);

		Task Update(TeacherSkill item);

		Task Delete(int id);

		Task<TeacherSkill> Get(int id);

		Task<List<TeacherSkill>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6da0d057cac727a43b45a9ac32a834ef</Hash>
</Codenesium>*/