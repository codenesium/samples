using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOTeacherXTeacherSkill
	{
		Task<CreateResponse<int>> Create(
			TeacherXTeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            TeacherXTeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOTeacherXTeacherSkill GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeacherXTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b0af6fbf1240717fe2c390ed20991374</Hash>
</Codenesium>*/