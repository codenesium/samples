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

		ApiResponse GetById(int id);

		POCOTeacherXTeacherSkill GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeacherXTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0dcf092a1bf71d8efe3fc1ed504f5aab</Hash>
</Codenesium>*/