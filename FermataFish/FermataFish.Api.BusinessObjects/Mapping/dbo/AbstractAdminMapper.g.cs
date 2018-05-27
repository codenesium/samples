using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLAdminMapper
	{
		public virtual DTOAdmin MapModelToDTO(
			int id,
			ApiAdminRequestModel model
			)
		{
			DTOAdmin dtoAdmin = new DTOAdmin();

			dtoAdmin.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.StudioId);
			return dtoAdmin;
		}

		public virtual ApiAdminResponseModel MapDTOToModel(
			DTOAdmin dtoAdmin)
		{
			if (dtoAdmin == null)
			{
				return null;
			}

			var model = new ApiAdminResponseModel();

			model.SetProperties(dtoAdmin.Birthday, dtoAdmin.Email, dtoAdmin.FirstName, dtoAdmin.Id, dtoAdmin.LastName, dtoAdmin.Phone, dtoAdmin.StudioId);

			return model;
		}

		public virtual List<ApiAdminResponseModel> MapDTOToModel(
			List<DTOAdmin> dtos)
		{
			List<ApiAdminResponseModel> response = new List<ApiAdminResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>de357cbbec6fdffe2bc413fceee62940</Hash>
</Codenesium>*/