using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IStudentRepository
	{
		Task<Student> Create(Student item);

		Task Update(Student item);

		Task Delete(int id);

		Task<Student> Get(int id);

		Task<List<Student>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Student>> ByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<Family> FamilyByFamilyId(int familyId);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>faf5ab86edad5848f58a057a663dbd78</Hash>
</Codenesium>*/