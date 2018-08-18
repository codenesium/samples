using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractSaleMapper
	{
		public virtual BOSale MapModelToBO(
			int id,
			ApiSaleRequestModel model
			)
		{
			BOSale boSale = new BOSale();
			boSale.SetProperties(
				id,
				model.Amount,
				model.ClientId,
				model.Note,
				model.PetId,
				model.SaleDate,
				model.SalesPersonId);
			return boSale;
		}

		public virtual ApiSaleResponseModel MapBOToModel(
			BOSale boSale)
		{
			var model = new ApiSaleResponseModel();

			model.SetProperties(boSale.Id, boSale.Amount, boSale.ClientId, boSale.Note, boSale.PetId, boSale.SaleDate, boSale.SalesPersonId);

			return model;
		}

		public virtual List<ApiSaleResponseModel> MapBOToModel(
			List<BOSale> items)
		{
			List<ApiSaleResponseModel> response = new List<ApiSaleResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dc37106956d0de2f0bdc0afe43d14969</Hash>
</Codenesium>*/