using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
				model.IpAddress,
				model.Notes,
				model.SaleDate,
				model.TransactionId);
			return boSale;
		}

		public virtual ApiSaleResponseModel MapBOToModel(
			BOSale boSale)
		{
			var model = new ApiSaleResponseModel();

			model.SetProperties(boSale.Id, boSale.IpAddress, boSale.Notes, boSale.SaleDate, boSale.TransactionId);

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
    <Hash>4b34ce6ca2eea4a75eac585a7fd5614c</Hash>
</Codenesium>*/