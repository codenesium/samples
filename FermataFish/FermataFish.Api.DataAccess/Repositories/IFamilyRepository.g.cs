using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface IFamilyRepository
	{
		Task<Family> Create(Family item);

		Task Update(Family item);

		Task Delete(int id);

		Task<Family> Get(int id);

		Task<List<Family>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> Students(int familyId, int limit = int.MaxValue, int offset = 0);

		Task<List<StudentXFamily>> StudentXFamilies(int familyId, int limit = int.MaxValue, int offset = 0);

		Task<Studio> GetStudio(int id);
	}
}

/*<Codenesium>
    <Hash>5f9a91ca9412feed108fe56e6c71f712</Hash>
</Codenesium>*/