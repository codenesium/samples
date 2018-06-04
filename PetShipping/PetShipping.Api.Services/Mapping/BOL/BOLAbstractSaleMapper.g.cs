using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractSaleMapper
	{
		public virtual BOSale MapModelToBO(
			int id,
			ApiSaleRequestModel model
			)
		{
			BOSale BOSale = new BOSale();

			BOSale.SetProperties(
				id,
				model.Amount,
				model.ClientId,
				model.Note,
				model.PetId,
				model.SaleDate,
				model.SalesPersonId);
			return BOSale;
		}

		public virtual ApiSaleResponseModel MapBOToModel(
			BOSale BOSale)
		{
			if (BOSale == null)
			{
				return null;
			}

			var model = new ApiSaleResponseModel();

			model.SetProperties(BOSale.Amount, BOSale.ClientId, BOSale.Id, BOSale.Note, BOSale.PetId, BOSale.SaleDate, BOSale.SalesPersonId);

			return model;
		}

		public virtual List<ApiSaleResponseModel> MapBOToModel(
			List<BOSale> BOs)
		{
			List<ApiSaleResponseModel> response = new List<ApiSaleResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>96a3b4fa634fa1bbab2c1c2f0c720486</Hash>
</Codenesium>*/