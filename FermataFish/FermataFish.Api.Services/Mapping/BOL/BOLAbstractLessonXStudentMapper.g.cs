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
			BOLessonXStudent BOLessonXStudent = new BOLessonXStudent();

			BOLessonXStudent.SetProperties(
				id,
				model.LessonId,
				model.StudentId);
			return BOLessonXStudent;
		}

		public virtual ApiLessonXStudentResponseModel MapBOToModel(
			BOLessonXStudent BOLessonXStudent)
		{
			if (BOLessonXStudent == null)
			{
				return null;
			}

			var model = new ApiLessonXStudentResponseModel();

			model.SetProperties(BOLessonXStudent.Id, BOLessonXStudent.LessonId, BOLessonXStudent.StudentId);

			return model;
		}

		public virtual List<ApiLessonXStudentResponseModel> MapBOToModel(
			List<BOLessonXStudent> BOs)
		{
			List<ApiLessonXStudentResponseModel> response = new List<ApiLessonXStudentResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6c19492557f1f30af1add56b41ca554c</Hash>
</Codenesium>*/