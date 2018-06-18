using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IStudentXFamilyRepository
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
    <Hash>e9d90351e4cd3a32ba14c82c54f85ab4</Hash>
</Codenesium>*/