using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
				model.IpAddress,
				model.Note,
				model.SaleDate,
				model.TransactionId);
			return boSale;
		}

		public virtual ApiSaleServerResponseModel MapBOToModel(
			BOSale boSale)
		{
			var model = new ApiSaleServerResponseModel();

			model.SetProperties(boSale.Id, boSale.IpAddress, boSale.Note, boSale.SaleDate, boSale.TransactionId);

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
    <Hash>8165acf2e3273e84be066a1b03258998</Hash>
</Codenesium>*/