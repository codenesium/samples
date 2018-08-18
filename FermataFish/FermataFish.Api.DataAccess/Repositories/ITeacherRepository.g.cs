using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface ITeacherRepository
	{
		Task<Teacher> Create(Teacher item);

		Task Update(Teacher item);

		Task Delete(int id);

		Task<Teacher> Get(int id);

		Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherXTeacherSkill>> TeacherXTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>8ccf54482364057e26279574fa968258</Hash>
</Codenesium>*/