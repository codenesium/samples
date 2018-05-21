using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentXFamilyRepository
	{
		Task<POCOStudentXFamily> Create(ApiStudentXFamilyModel model);

		Task Update(int id,
		            ApiStudentXFamilyModel model);

		Task Delete(int id);

		Task<POCOStudentXFamily> Get(int id);

		Task<List<POCOStudentXFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>86da442336511c54b7433a08f0445d1a</Hash>
</Codenesium>*/