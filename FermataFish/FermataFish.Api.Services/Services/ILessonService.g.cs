using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface ILessonService
	{
		Task<CreateResponse<ApiLessonResponseModel>> Create(
			ApiLessonRequestModel model);

		Task<UpdateResponse<ApiLessonResponseModel>> Update(int id,
		                                                     ApiLessonRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLessonResponseModel> Get(int id);

		Task<List<ApiLessonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a5d24f29f3465ddc859525bc89c86452</Hash>
</Codenesium>*/