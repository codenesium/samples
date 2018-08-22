using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractLessonXStudentMapper
	{
		public virtual BOLessonXStudent MapModelToBO(
			int id,
			ApiLessonXStudentRequestModel model
			)
		{
			BOLessonXStudent boLessonXStudent = new BOLessonXStudent();
			boLessonXStudent.SetProperties(
				id,
				model.LessonId,
				model.StudentId,
				model.StudioId);
			return boLessonXStudent;
		}

		public virtual ApiLessonXStudentResponseModel MapBOToModel(
			BOLessonXStudent boLessonXStudent)
		{
			var model = new ApiLessonXStudentResponseModel();

			model.SetProperties(boLessonXStudent.Id, boLessonXStudent.LessonId, boLessonXStudent.StudentId, boLessonXStudent.StudioId);

			return model;
		}

		public virtual List<ApiLessonXStudentResponseModel> MapBOToModel(
			List<BOLessonXStudent> items)
		{
			List<ApiLessonXStudentResponseModel> response = new List<ApiLessonXStudentResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e7fc20e327fa5cf3076ed5cb1cd2540d</Hash>
</Codenesium>*/