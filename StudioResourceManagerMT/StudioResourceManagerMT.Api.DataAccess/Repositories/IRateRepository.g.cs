using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IRateRepository
	{
		Task<Rate> Create(Rate item);

		Task Update(Rate item);

		Task Delete(int id);

		Task<Rate> Get(int id);

		Task<List<Rate>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Teacher> TeacherByTeacherId(int teacherId);

		Task<TeacherSkill> TeacherSkillByTeacherSkillId(int teacherSkillId);
	}
}

/*<Codenesium>
    <Hash>0ccf466c00abcda23e8488b26785bbf5</Hash>
</Codenesium>*/