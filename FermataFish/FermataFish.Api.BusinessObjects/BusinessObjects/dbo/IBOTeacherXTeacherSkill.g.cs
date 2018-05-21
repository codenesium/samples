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
		Task<CreateResponse<POCOTeacherXTeacherSkill>> Create(
			ApiTeacherXTeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeacherXTeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOTeacherXTeacherSkill> Get(int id);

		Task<List<POCOTeacherXTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cb4932ce39de0d61806fa6874e0d7230</Hash>
</Codenesium>*/