using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOTeacherSkill
	{
		Task<CreateResponse<int>> Create(
			TeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            TeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOTeacherSkill GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>03e181702772d751166bcca3b8fce544</Hash>
</Codenesium>*/