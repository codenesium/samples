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
				model.StudentId);
			return boLessonXStudent;
		}

		public virtual ApiLessonXStudentResponseModel MapBOToModel(
			BOLessonXStudent boLessonXStudent)
		{
			var model = new ApiLessonXStudentResponseModel();

			model.SetProperties(boLessonXStudent.Id, boLessonXStudent.LessonId, boLessonXStudent.StudentId);

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
    <Hash>daf4299cfceef7c41535db4eecf89d30</Hash>
</Codenesium>*/