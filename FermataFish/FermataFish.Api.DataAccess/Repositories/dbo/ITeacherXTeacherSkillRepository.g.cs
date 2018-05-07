using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherXTeacherSkillRepository
	{
		int Create(TeacherXTeacherSkillModel model);

		void Update(int id,
		            TeacherXTeacherSkillModel model);

		void Delete(int id);

		POCOTeacherXTeacherSkill Get(int id);

		List<POCOTeacherXTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f4a8cc8ca665aa89c24d537d7b466abb</Hash>
</Codenesium>*/