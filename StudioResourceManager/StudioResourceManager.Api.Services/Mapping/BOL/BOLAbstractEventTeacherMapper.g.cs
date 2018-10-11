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
				model.TeacherId);
			return boEventTeacher;
		}

		public virtual ApiEventTeacherResponseModel MapBOToModel(
			BOEventTeacher boEventTeacher)
		{
			var model = new ApiEventTeacherResponseModel();

			model.SetProperties(boEventTeacher.EventId, boEventTeacher.TeacherId);

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
    <Hash>d0343bbad4caf76e76e6f16c82f3777c</Hash>
</Codenesium>*/