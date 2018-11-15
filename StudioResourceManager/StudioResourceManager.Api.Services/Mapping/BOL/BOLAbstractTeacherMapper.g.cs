using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractTeacherMapper
	{
		public virtual BOTeacher MapModelToBO(
			int id,
			ApiTeacherServerRequestModel model
			)
		{
			BOTeacher boTeacher = new BOTeacher();
			boTeacher.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.UserId);
			return boTeacher;
		}

		public virtual ApiTeacherServerResponseModel MapBOToModel(
			BOTeacher boTeacher)
		{
			var model = new ApiTeacherServerResponseModel();

			model.SetProperties(boTeacher.Id, boTeacher.Birthday, boTeacher.Email, boTeacher.FirstName, boTeacher.LastName, boTeacher.Phone, boTeacher.UserId);

			return model;
		}

		public virtual List<ApiTeacherServerResponseModel> MapBOToModel(
			List<BOTeacher> items)
		{
			List<ApiTeacherServerResponseModel> response = new List<ApiTeacherServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2f4b74aba9be89544d624da1958b5e6f</Hash>
</Codenesium>*/