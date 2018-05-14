using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherSkillRepository
	{
		POCOTeacherSkill Create(TeacherSkillModel model);

		void Update(int id,
		            TeacherSkillModel model);

		void Delete(int id);

		POCOTeacherSkill Get(int id);

		List<POCOTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c2f8b6ba2fec286e019836cc84605456</Hash>
</Codenesium>*/