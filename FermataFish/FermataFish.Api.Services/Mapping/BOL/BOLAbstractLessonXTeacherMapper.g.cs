using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractLessonXTeacherMapper
	{
		public virtual BOLessonXTeacher MapModelToBO(
			int id,
			ApiLessonXTeacherRequestModel model
			)
		{
			BOLessonXTeacher BOLessonXTeacher = new BOLessonXTeacher();

			BOLessonXTeacher.SetProperties(
				id,
				model.LessonId,
				model.StudentId);
			return BOLessonXTeacher;
		}

		public virtual ApiLessonXTeacherResponseModel MapBOToModel(
			BOLessonXTeacher BOLessonXTeacher)
		{
			if (BOLessonXTeacher == null)
			{
				return null;
			}

			var model = new ApiLessonXTeacherResponseModel();

			model.SetProperties(BOLessonXTeacher.Id, BOLessonXTeacher.LessonId, BOLessonXTeacher.StudentId);

			return model;
		}

		public virtual List<ApiLessonXTeacherResponseModel> MapBOToModel(
			List<BOLessonXTeacher> BOs)
		{
			List<ApiLessonXTeacherResponseModel> response = new List<ApiLessonXTeacherResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>efbf8229a21b54d3dc4af9b710fb9a83</Hash>
</Codenesium>*/