using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractEventStudentMapper
	{
		public virtual BOEventStudent MapModelToBO(
			int id,
			ApiEventStudentRequestModel model
			)
		{
			BOEventStudent boEventStudent = new BOEventStudent();
			boEventStudent.SetProperties(
				id,
				model.EventId,
				model.StudentId);
			return boEventStudent;
		}

		public virtual ApiEventStudentResponseModel MapBOToModel(
			BOEventStudent boEventStudent)
		{
			var model = new ApiEventStudentResponseModel();

			model.SetProperties(boEventStudent.Id, boEventStudent.EventId, boEventStudent.StudentId);

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
    <Hash>616d769b483807b8b38f06ed02f1727a</Hash>
</Codenesium>*/