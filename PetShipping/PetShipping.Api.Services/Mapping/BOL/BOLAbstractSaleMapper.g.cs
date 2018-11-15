using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
				model.CutomerId,
				model.Note,
				model.PetId,
				model.SaleDate,
				model.SalesPersonId);
			return boSale;
		}

		public virtual ApiSaleServerResponseModel MapBOToModel(
			BOSale boSale)
		{
			var model = new ApiSaleServerResponseModel();

			model.SetProperties(boSale.Id, boSale.Amount, boSale.CutomerId, boSale.Note, boSale.PetId, boSale.SaleDate, boSale.SalesPersonId);

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
    <Hash>3645704656e8e26871c4789b1ab53ca9</Hash>
</Codenesium>*/