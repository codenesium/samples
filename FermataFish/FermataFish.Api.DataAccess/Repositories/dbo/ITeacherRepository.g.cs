using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherRepository
	{
		Task<POCOTeacher> Create(ApiTeacherModel model);

		Task Update(int id,
		            ApiTeacherModel model);

		Task Delete(int id);

		Task<POCOTeacher> Get(int id);

		Task<List<POCOTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>35e4a09d7f5222c8b719f730871758f4</Hash>
</Codenesium>*/