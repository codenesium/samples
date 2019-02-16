using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCreditCardMapper
	{
		public virtual CreditCard MapModelToBO(
			int creditCardID,
			ApiCreditCardServerRequestModel model
			)
		{
			CreditCard item = new CreditCard();
			item.SetProperties(
				creditCardID,
				model.CardNumber,
				model.CardType,
				model.ExpMonth,
				model.ExpYear,
				model.ModifiedDate);
			return item;
		}

		public virtual ApiCreditCardServerResponseModel MapBOToModel(
			CreditCard item)
		{
			var model = new ApiCreditCardServerResponseModel();

			model.SetProperties(item.CreditCardID, item.CardNumber, item.CardType, item.ExpMonth, item.ExpYear, item.ModifiedDate);

			return model;
		}

		public virtual List<ApiCreditCardServerResponseModel> MapBOToModel(
			List<CreditCard> items)
		{
			List<ApiCreditCardServerResponseModel> response = new List<ApiCreditCardServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7a1a57f40e1f394052b4e88da9e2cd42</Hash>
</Codenesium>*/