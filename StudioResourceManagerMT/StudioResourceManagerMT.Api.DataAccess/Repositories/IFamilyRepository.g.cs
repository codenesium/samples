using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IFamilyRepository
	{
		Task<Family> Create(Family item);

		Task Update(Family item);

		Task Delete(int id);

		Task<Family> Get(int id);

		Task<List<Family>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Student>> StudentsByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ef3671fb11d523c2a0d4e5388821d8e4</Hash>
</Codenesium>*/