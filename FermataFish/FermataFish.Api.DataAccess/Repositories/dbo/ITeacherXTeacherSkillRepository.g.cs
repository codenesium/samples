using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherXTeacherSkillRepository
	{
		POCOTeacherXTeacherSkill Create(ApiTeacherXTeacherSkillModel model);

		void Update(int id,
		            ApiTeacherXTeacherSkillModel model);

		void Delete(int id);

		POCOTeacherXTeacherSkill Get(int id);

		List<POCOTeacherXTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6f23110fd5789cb516028e11fc02658d</Hash>
</Codenesium>*/