using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractTeacherMapper
	{
		public virtual BOTeacher MapModelToBO(
			int id,
			ApiTeacherRequestModel model
			)
		{
			BOTeacher BOTeacher = new BOTeacher();

			BOTeacher.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.StudioId);
			return BOTeacher;
		}

		public virtual ApiTeacherResponseModel MapBOToModel(
			BOTeacher BOTeacher)
		{
			if (BOTeacher == null)
			{
				return null;
			}

			var model = new ApiTeacherResponseModel();

			model.SetProperties(BOTeacher.Birthday, BOTeacher.Email, BOTeacher.FirstName, BOTeacher.Id, BOTeacher.LastName, BOTeacher.Phone, BOTeacher.StudioId);

			return model;
		}

		public virtual List<ApiTeacherResponseModel> MapBOToModel(
			List<BOTeacher> BOs)
		{
			List<ApiTeacherResponseModel> response = new List<ApiTeacherResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3cf3405ca921e139fe5f3f5bc9ce78e7</Hash>
</Codenesium>*/