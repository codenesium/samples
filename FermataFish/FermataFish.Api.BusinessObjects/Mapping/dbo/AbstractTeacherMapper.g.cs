using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLTeacherMapper
	{
		public virtual DTOTeacher MapModelToDTO(
			int id,
			ApiTeacherRequestModel model
			)
		{
			DTOTeacher dtoTeacher = new DTOTeacher();

			dtoTeacher.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.StudioId);
			return dtoTeacher;
		}

		public virtual ApiTeacherResponseModel MapDTOToModel(
			DTOTeacher dtoTeacher)
		{
			if (dtoTeacher == null)
			{
				return null;
			}

			var model = new ApiTeacherResponseModel();

			model.SetProperties(dtoTeacher.Birthday, dtoTeacher.Email, dtoTeacher.FirstName, dtoTeacher.Id, dtoTeacher.LastName, dtoTeacher.Phone, dtoTeacher.StudioId);

			return model;
		}

		public virtual List<ApiTeacherResponseModel> MapDTOToModel(
			List<DTOTeacher> dtos)
		{
			List<ApiTeacherResponseModel> response = new List<ApiTeacherResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b6282c2b008e3d8b95154718e96a4ed8</Hash>
</Codenesium>*/