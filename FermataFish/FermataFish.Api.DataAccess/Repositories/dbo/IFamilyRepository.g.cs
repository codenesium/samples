using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IFamilyRepository
	{
		Task<POCOFamily> Create(ApiFamilyModel model);

		Task Update(int id,
		            ApiFamilyModel model);

		Task Delete(int id);

		Task<POCOFamily> Get(int id);

		Task<List<POCOFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>23f4ddaa78eaf7bc646cbe3b49dadcda</Hash>
</Codenesium>*/