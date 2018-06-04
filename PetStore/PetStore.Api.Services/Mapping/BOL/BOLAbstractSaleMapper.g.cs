using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
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
				model.FirstName,
				model.LastName,
				model.PaymentTypeId,
				model.PetId,
				model.Phone);
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

			model.SetProperties(BOSale.Amount, BOSale.FirstName, BOSale.Id, BOSale.LastName, BOSale.PaymentTypeId, BOSale.PetId, BOSale.Phone);

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
    <Hash>80fbb88ef5ec9b3965a7da521b307f9e</Hash>
</Codenesium>*/