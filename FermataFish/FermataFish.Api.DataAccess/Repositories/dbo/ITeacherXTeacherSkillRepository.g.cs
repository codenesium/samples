using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherXTeacherSkillRepository
	{
		int Create(
			int teacherId,
			int teacherSkillId);

		void Update(int id,
		            int teacherId,
		            int teacherSkillId);

		void Delete(int id);

		Response GetById(int id);

		POCOTeacherXTeacherSkill GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeacherXTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>840cee017fa81f3b7562f211662d0bb0</Hash>
</Codenesium>*/