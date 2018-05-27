using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLOrganizationMapper
	{
		public virtual DTOOrganization MapModelToDTO(
			int id,
			ApiOrganizationRequestModel model
			)
		{
			DTOOrganization dtoOrganization = new DTOOrganization();

			dtoOrganization.SetProperties(
				id,
				model.Name);
			return dtoOrganization;
		}

		public virtual ApiOrganizationResponseModel MapDTOToModel(
			DTOOrganization dtoOrganization)
		{
			if (dtoOrganization == null)
			{
				return null;
			}

			var model = new ApiOrganizationResponseModel();

			model.SetProperties(dtoOrganization.Id, dtoOrganization.Name);

			return model;
		}

		public virtual List<ApiOrganizationResponseModel> MapDTOToModel(
			List<DTOOrganization> dtos)
		{
			List<ApiOrganizationResponseModel> response = new List<ApiOrganizationResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b026e0ff694beba57857ec5cda84aed1</Hash>
</Codenesium>*/