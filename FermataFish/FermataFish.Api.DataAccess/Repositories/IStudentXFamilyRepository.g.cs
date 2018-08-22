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

		Task<List<StudentXFamily>> ByStudioId(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<Family> GetFamily(int familyId);

		Task<Student> GetStudent(int studentId);

		Task<Studio> GetStudio(int studioId);
	}
}

/*<Codenesium>
    <Hash>fa09cfac03e8885b7fc038ba8a53f3a6</Hash>
</Codenesium>*/