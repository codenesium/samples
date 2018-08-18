using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface IStudentXFamilyRepository
	{
		Task<StudentXFamily> Create(StudentXFamily item);

		Task Update(StudentXFamily item);

		Task Delete(int id);

		Task<StudentXFamily> Get(int id);

		Task<List<StudentXFamily>> All(int limit = int.MaxValue, int offset = 0);

		Task<Family> GetFamily(int familyId);

		Task<Student> GetStudent(int studentId);
	}
}

/*<Codenesium>
    <Hash>8c757c02dcb641780c843f05d42d5690</Hash>
</Codenesium>*/