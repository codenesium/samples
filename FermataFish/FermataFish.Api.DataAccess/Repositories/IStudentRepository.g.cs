using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface IStudentRepository
	{
		Task<Student> Create(Student item);

		Task Update(Student item);

		Task Delete(int id);

		Task<Student> Get(int id);

		Task<List<Student>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<LessonXStudent>> LessonXStudents(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<List<LessonXTeacher>> LessonXTeachers(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<List<StudentXFamily>> StudentXFamilies(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<Family> GetFamily(int familyId);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>23e96e2b0eee3e61b5a66a0b3ad88ff9</Hash>
</Codenesium>*/