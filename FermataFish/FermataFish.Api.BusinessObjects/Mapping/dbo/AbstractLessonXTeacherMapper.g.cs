using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLLessonXTeacherMapper
	{
		public virtual DTOLessonXTeacher MapModelToDTO(
			int id,
			ApiLessonXTeacherRequestModel model
			)
		{
			DTOLessonXTeacher dtoLessonXTeacher = new DTOLessonXTeacher();

			dtoLessonXTeacher.SetProperties(
				id,
				model.LessonId,
				model.StudentId);
			return dtoLessonXTeacher;
		}

		public virtual ApiLessonXTeacherResponseModel MapDTOToModel(
			DTOLessonXTeacher dtoLessonXTeacher)
		{
			if (dtoLessonXTeacher == null)
			{
				return null;
			}

			var model = new ApiLessonXTeacherResponseModel();

			model.SetProperties(dtoLessonXTeacher.Id, dtoLessonXTeacher.LessonId, dtoLessonXTeacher.StudentId);

			return model;
		}

		public virtual List<ApiLessonXTeacherResponseModel> MapDTOToModel(
			List<DTOLessonXTeacher> dtos)
		{
			List<ApiLessonXTeacherResponseModel> response = new List<ApiLessonXTeacherResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aa6fd210f4c9124aaed0285e6a7c6110</Hash>
</Codenesium>*/