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

		Task<List<Student>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<EventStudent>> EventStudentsByStudentId(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<Family> FamilyByFamilyId(int familyId);

		Task<User> UserByUserId(int userId);
	}
}

/*<Codenesium>
    <Hash>79b18a9e28c5b57d47392f5c77b1857c</Hash>
</Codenesium>*/