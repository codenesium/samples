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
		Task<CreateResponse<POCOTeacherSkill>> Create(
			ApiTeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOTeacherSkill> Get(int id);

		Task<List<POCOTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>65da22236f7949a85a2edc701aeccab7</Hash>
</Codenesium>*/