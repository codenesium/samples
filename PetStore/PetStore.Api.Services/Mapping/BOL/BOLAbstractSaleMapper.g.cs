using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractSaleMapper
	{
		public virtual BOSale MapModelToBO(
			int id,
			ApiSaleServerRequestModel model
			)
		{
			BOSale boSale = new BOSale();
			boSale.SetProperties(
				id,
				model.Amount,
				model.FirstName,
				model.LastName,
				model.PaymentTypeId,
				model.PetId,
				model.Phone);
			return boSale;
		}

		public virtual ApiSaleServerResponseModel MapBOToModel(
			BOSale boSale)
		{
			var model = new ApiSaleServerResponseModel();

			model.SetProperties(boSale.Id, boSale.Amount, boSale.FirstName, boSale.LastName, boSale.PaymentTypeId, boSale.PetId, boSale.Phone);

			return model;
		}

		public virtual List<ApiSaleServerResponseModel> MapBOToModel(
			List<BOSale> items)
		{
			List<ApiSaleServerResponseModel> response = new List<ApiSaleServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0ec782a53b72dca5e9860f3881bf7442</Hash>
</Codenesium>*/