using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public partial interface IStudioRepository
	{
		Task<Studio> Create(Studio item);

		Task Update(Studio item);

		Task Delete(int id);

		Task<Studio> Get(int id);

		Task<List<Studio>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Family>> Families(int id, int limit = int.MaxValue, int offset = 0);

		Task<List<LessonStatus>> LessonStatuses(int id, int limit = int.MaxValue, int offset = 0);

		Task<List<Admin>> Admins(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<Lesson>> Lessons(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<LessonXStudent>> LessonXStudents(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<Rate>> Rates(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<Space>> Spaces(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceFeature>> SpaceFeatures(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<SpaceXSpaceFeature>> SpaceXSpaceFeatures(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<Student>> Students(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<StudentXFamily>> StudentXFamilies(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<Teacher>> Teachers(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherSkill>> TeacherSkills(int studioId, int limit = int.MaxValue, int offset = 0);

		Task<List<TeacherXTeacherSkill>> TeacherXTeacherSkills(int studioId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b10bd4ca6f99e7982c6747d8e495d7dc</Hash>
</Codenesium>*/