using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSaleMapper
	{
		public virtual DTOSale MapModelToDTO(
			int id,
			ApiSaleRequestModel model
			)
		{
			DTOSale dtoSale = new DTOSale();

			dtoSale.SetProperties(
				id,
				model.Amount,
				model.ClientId,
				model.Note,
				model.PetId,
				model.SaleDate,
				model.SalesPersonId);
			return dtoSale;
		}

		public virtual ApiSaleResponseModel MapDTOToModel(
			DTOSale dtoSale)
		{
			if (dtoSale == null)
			{
				return null;
			}

			var model = new ApiSaleResponseModel();

			model.SetProperties(dtoSale.Amount, dtoSale.ClientId, dtoSale.Id, dtoSale.Note, dtoSale.PetId, dtoSale.SaleDate, dtoSale.SalesPersonId);

			return model;
		}

		public virtual List<ApiSaleResponseModel> MapDTOToModel(
			List<DTOSale> dtos)
		{
			List<ApiSaleResponseModel> response = new List<ApiSaleResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>614252c2274f3b10a7024359527dce57</Hash>
</Codenesium>*/