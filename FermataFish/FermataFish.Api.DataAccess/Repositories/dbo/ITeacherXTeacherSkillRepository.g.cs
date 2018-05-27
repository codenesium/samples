using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherXTeacherSkillRepository
	{
		Task<DTOTeacherXTeacherSkill> Create(DTOTeacherXTeacherSkill dto);

		Task Update(int id,
		            DTOTeacherXTeacherSkill dto);

		Task Delete(int id);

		Task<DTOTeacherXTeacherSkill> Get(int id);

		Task<List<DTOTeacherXTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3eb29577e227c3a321caa8b8eb8fe335</Hash>
</Codenesium>*/