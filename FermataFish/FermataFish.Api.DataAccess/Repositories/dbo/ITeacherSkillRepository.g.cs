using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherSkillRepository
	{
		Task<DTOTeacherSkill> Create(DTOTeacherSkill dto);

		Task Update(int id,
		            DTOTeacherSkill dto);

		Task Delete(int id);

		Task<DTOTeacherSkill> Get(int id);

		Task<List<DTOTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ce1db8de03de543db82b390c9495de87</Hash>
</Codenesium>*/