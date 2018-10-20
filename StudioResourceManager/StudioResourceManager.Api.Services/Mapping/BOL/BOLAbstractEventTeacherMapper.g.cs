using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractEventTeacherMapper
	{
		public virtual BOEventTeacher MapModelToBO(
			int eventId,
			ApiEventTeacherRequestModel model
			)
		{
			BOEventTeacher boEventTeacher = new BOEventTeacher();
			boEventTeacher.SetProperties(
				eventId,
				model.TeacherId,
				model.IsDeleted);
			return boEventTeacher;
		}

		public virtual ApiEventTeacherResponseModel MapBOToModel(
			BOEventTeacher boEventTeacher)
		{
			var model = new ApiEventTeacherResponseModel();

			model.SetProperties(boEventTeacher.EventId, boEventTeacher.TeacherId, boEventTeacher.IsDeleted);

			return model;
		}

		public virtual List<ApiEventTeacherResponseModel> MapBOToModel(
			List<BOEventTeacher> items)
		{
			List<ApiEventTeacherResponseModel> response = new List<ApiEventTeacherResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c09a6b320096bee27771fcc7d8e714c1</Hash>
</Codenesium>*/