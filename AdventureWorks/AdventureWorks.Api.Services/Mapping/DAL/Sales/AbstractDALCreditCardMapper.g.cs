using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCreditCardMapper
	{
		public virtual CreditCard MapModelToEntity(
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

		public virtual ApiCreditCardServerResponseModel MapEntityToModel(
			CreditCard item)
		{
			var model = new ApiCreditCardServerResponseModel();

			model.SetProperties(item.CreditCardID,
			                    item.CardNumber,
			                    item.CardType,
			                    item.ExpMonth,
			                    item.ExpYear,
			                    item.ModifiedDate);

			return model;
		}

		public virtual List<ApiCreditCardServerResponseModel> MapEntityToModel(
			List<CreditCard> items)
		{
			List<ApiCreditCardServerResponseModel> response = new List<ApiCreditCardServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b4cbb11710f42de519c115d2447efb6f</Hash>
</Codenesium>*/