using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherSkillRepository
	{
		int Create(TeacherSkillModel model);

		void Update(int id,
		            TeacherSkillModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOTeacherSkill GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b1cc59b4bec5a68c3a3467bf14d722f7</Hash>
</Codenesium>*/