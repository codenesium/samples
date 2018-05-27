using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
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
				model.FirstName,
				model.LastName,
				model.PaymentTypeId,
				model.PetId,
				model.Phone);
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

			model.SetProperties(dtoSale.Amount, dtoSale.FirstName, dtoSale.Id, dtoSale.LastName, dtoSale.PaymentTypeId, dtoSale.PetId, dtoSale.Phone);

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
    <Hash>41d273091a068582c9e4c6366a9ffe2d</Hash>
</Codenesium>*/