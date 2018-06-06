using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>796d6593ccebf2d87d1682b3ad8f8da8</Hash>
</Codenesium>*/