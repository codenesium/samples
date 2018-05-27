using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLLessonXStudentMapper
	{
		public virtual DTOLessonXStudent MapModelToDTO(
			int id,
			ApiLessonXStudentRequestModel model
			)
		{
			DTOLessonXStudent dtoLessonXStudent = new DTOLessonXStudent();

			dtoLessonXStudent.SetProperties(
				id,
				model.LessonId,
				model.StudentId);
			return dtoLessonXStudent;
		}

		public virtual ApiLessonXStudentResponseModel MapDTOToModel(
			DTOLessonXStudent dtoLessonXStudent)
		{
			if (dtoLessonXStudent == null)
			{
				return null;
			}

			var model = new ApiLessonXStudentResponseModel();

			model.SetProperties(dtoLessonXStudent.Id, dtoLessonXStudent.LessonId, dtoLessonXStudent.StudentId);

			return model;
		}

		public virtual List<ApiLessonXStudentResponseModel> MapDTOToModel(
			List<DTOLessonXStudent> dtos)
		{
			List<ApiLessonXStudentResponseModel> response = new List<ApiLessonXStudentResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cae74fdb12ad7167fcd22c209e8c1f81</Hash>
</Codenesium>*/