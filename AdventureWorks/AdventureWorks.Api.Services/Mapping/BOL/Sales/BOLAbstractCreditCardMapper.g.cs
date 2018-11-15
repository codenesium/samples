using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCreditCardMapper
	{
		public virtual BOCreditCard MapModelToBO(
			int creditCardID,
			ApiCreditCardServerRequestModel model
			)
		{
			BOCreditCard boCreditCard = new BOCreditCard();
			boCreditCard.SetProperties(
				creditCardID,
				model.CardNumber,
				model.CardType,
				model.ExpMonth,
				model.ExpYear,
				model.ModifiedDate);
			return boCreditCard;
		}

		public virtual ApiCreditCardServerResponseModel MapBOToModel(
			BOCreditCard boCreditCard)
		{
			var model = new ApiCreditCardServerResponseModel();

			model.SetProperties(boCreditCard.CreditCardID, boCreditCard.CardNumber, boCreditCard.CardType, boCreditCard.ExpMonth, boCreditCard.ExpYear, boCreditCard.ModifiedDate);

			return model;
		}

		public virtual List<ApiCreditCardServerResponseModel> MapBOToModel(
			List<BOCreditCard> items)
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
    <Hash>b76b66678e881e6afbf36d808aa29e8b</Hash>
</Codenesium>*/