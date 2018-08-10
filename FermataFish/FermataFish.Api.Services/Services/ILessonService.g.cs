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
    <Hash>27a0f06b1f00e3af7e07153cd2b846a9</Hash>
</Codenesium>*/