using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IStudioRepository
        {
                Task<Studio> Create(Studio item);

                Task Update(Studio item);

                Task Delete(int id);

                Task<Studio> Get(int id);

                Task<List<Studio>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Admin>> Admins(int studioId, int limit = int.MaxValue, int offset = 0);

                Task<List<Family>> Families(int id, int limit = int.MaxValue, int offset = 0);

                Task<List<Lesson>> Lessons(int studioId, int limit = int.MaxValue, int offset = 0);

                Task<List<LessonStatus>> LessonStatus(int id, int limit = int.MaxValue, int offset = 0);

                Task<List<Space>> Spaces(int studioId, int limit = int.MaxValue, int offset = 0);

                Task<List<SpaceFeature>> SpaceFeatures(int studioId, int limit = int.MaxValue, int offset = 0);

                Task<List<Student>> Students(int studioId, int limit = int.MaxValue, int offset = 0);

                Task<List<Teacher>> Teachers(int studioId, int limit = int.MaxValue, int offset = 0);

                Task<List<TeacherSkill>> TeacherSkills(int studioId, int limit = int.MaxValue, int offset = 0);

                Task<State> GetState(int stateId);
        }
}

/*<Codenesium>
    <Hash>b0a4f548b65ab4e98afd174eee219ff0</Hash>
</Codenesium>*/