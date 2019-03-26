using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IStudentRepository
	{
		Task<Student> Create(Student item);

		Task Update(Student item);

		Task Delete(int id);

		Task<Student> Get(int id);

		Task<List<Student>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Family> FamilyByFamilyId(int familyId);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>c544a343b2c726431b500856244bda0e</Hash>
</Codenesium>*/