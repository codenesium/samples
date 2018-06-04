using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentRepository
	{
		Task<Student> Create(Student item);

		Task Update(Student item);

		Task Delete(int id);

		Task<Student> Get(int id);

		Task<List<Student>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e39033d95c2b5f3411e9172b40e697f8</Hash>
</Codenesium>*/