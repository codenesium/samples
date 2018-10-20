using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractTeacherMapper
	{
		public virtual BOTeacher MapModelToBO(
			int id,
			ApiTeacherRequestModel model
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
				model.UserId,
				model.IsDeleted);
			return boTeacher;
		}

		public virtual ApiTeacherResponseModel MapBOToModel(
			BOTeacher boTeacher)
		{
			var model = new ApiTeacherResponseModel();

			model.SetProperties(boTeacher.Id, boTeacher.Birthday, boTeacher.Email, boTeacher.FirstName, boTeacher.LastName, boTeacher.Phone, boTeacher.UserId, boTeacher.IsDeleted);

			return model;
		}

		public virtual List<ApiTeacherResponseModel> MapBOToModel(
			List<BOTeacher> items)
		{
			List<ApiTeacherResponseModel> response = new List<ApiTeacherResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7cec35926a5c263b3c6729bfed16b696</Hash>
</Codenesium>*/