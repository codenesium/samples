using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractEventTeacherMapper
	{
		public virtual BOEventTeacher MapModelToBO(
			int id,
			ApiEventTeacherRequestModel model
			)
		{
			BOEventTeacher boEventTeacher = new BOEventTeacher();
			boEventTeacher.SetProperties(
				id,
				model.EventId);
			return boEventTeacher;
		}

		public virtual ApiEventTeacherResponseModel MapBOToModel(
			BOEventTeacher boEventTeacher)
		{
			var model = new ApiEventTeacherResponseModel();

			model.SetProperties(boEventTeacher.Id, boEventTeacher.EventId);

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
    <Hash>15b00a3500fcd398cc57087661ae7e66</Hash>
</Codenesium>*/