using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractEventStudentMapper
	{
		public virtual BOEventStudent MapModelToBO(
			int eventId,
			ApiEventStudentRequestModel model
			)
		{
			BOEventStudent boEventStudent = new BOEventStudent();
			boEventStudent.SetProperties(
				eventId,
				model.StudentId);
			return boEventStudent;
		}

		public virtual ApiEventStudentResponseModel MapBOToModel(
			BOEventStudent boEventStudent)
		{
			var model = new ApiEventStudentResponseModel();

			model.SetProperties(boEventStudent.EventId, boEventStudent.StudentId);

			return model;
		}

		public virtual List<ApiEventStudentResponseModel> MapBOToModel(
			List<BOEventStudent> items)
		{
			List<ApiEventStudentResponseModel> response = new List<ApiEventStudentResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8913e59c24c406b561b5a28ac3ab2420</Hash>
</Codenesium>*/