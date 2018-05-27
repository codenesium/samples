using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPenMapper
	{
		public virtual DTOPen MapModelToDTO(
			int id,
			ApiPenRequestModel model
			)
		{
			DTOPen dtoPen = new DTOPen();

			dtoPen.SetProperties(
				id,
				model.Name);
			return dtoPen;
		}

		public virtual ApiPenResponseModel MapDTOToModel(
			DTOPen dtoPen)
		{
			if (dtoPen == null)
			{
				return null;
			}

			var model = new ApiPenResponseModel();

			model.SetProperties(dtoPen.Id, dtoPen.Name);

			return model;
		}

		public virtual List<ApiPenResponseModel> MapDTOToModel(
			List<DTOPen> dtos)
		{
			List<ApiPenResponseModel> response = new List<ApiPenResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>db932b6d0d2be77e5550e5daa1741fbc</Hash>
</Codenesium>*/