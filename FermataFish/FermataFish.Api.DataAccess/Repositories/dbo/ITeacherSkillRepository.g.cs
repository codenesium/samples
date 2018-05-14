using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherSkillRepository
	{
		POCOTeacherSkill Create(ApiTeacherSkillModel model);

		void Update(int id,
		            ApiTeacherSkillModel model);

		void Delete(int id);

		POCOTeacherSkill Get(int id);

		List<POCOTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>127296cfff120beab8eadf2d32108c0e</Hash>
</Codenesium>*/