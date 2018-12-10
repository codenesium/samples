using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IFamilyRepository
	{
		Task<Family> Create(Family item);

		Task Update(Family item);

		Task Delete(int id);

		Task<Family> Get(int id);

		Task<List<Family>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> StudentsByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2f2713a89a6a3c5f3d6aef70d9413692</Hash>
</Codenesium>*/