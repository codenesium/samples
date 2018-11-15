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

		Task<List<Family>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<Student> CreateStudent(Student item);

		Task DeleteStudent(Student item);
	}
}

/*<Codenesium>
    <Hash>386490a0c31e3d968fbd9e15a889677c</Hash>
</Codenesium>*/