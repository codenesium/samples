using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherXTeacherSkillRepository
	{
		POCOTeacherXTeacherSkill Create(TeacherXTeacherSkillModel model);

		void Update(int id,
		            TeacherXTeacherSkillModel model);

		void Delete(int id);

		POCOTeacherXTeacherSkill Get(int id);

		List<POCOTeacherXTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>79770e0e032413f45d5e9549c2644837</Hash>
</Codenesium>*/