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

		Task<List<Student>> ByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<Family> FamilyByFamilyId(int familyId);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>9cbf02fe49ff2c17f34b4d92e24dae66</Hash>
</Codenesium>*/