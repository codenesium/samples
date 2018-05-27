using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherRepository
	{
		Task<DTOTeacher> Create(DTOTeacher dto);

		Task Update(int id,
		            DTOTeacher dto);

		Task Delete(int id);

		Task<DTOTeacher> Get(int id);

		Task<List<DTOTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>86e294d25324e6d1b814a83222c5e637</Hash>
</Codenesium>*/