using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCreditCardMapper
	{
		public virtual BOCreditCard MapModelToBO(
			int creditCardID,
			ApiCreditCardRequestModel model
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

		public virtual ApiCreditCardResponseModel MapBOToModel(
			BOCreditCard boCreditCard)
		{
			var model = new ApiCreditCardResponseModel();

			model.SetProperties(boCreditCard.CreditCardID, boCreditCard.CardNumber, boCreditCard.CardType, boCreditCard.ExpMonth, boCreditCard.ExpYear, boCreditCard.ModifiedDate);

			return model;
		}

		public virtual List<ApiCreditCardResponseModel> MapBOToModel(
			List<BOCreditCard> items)
		{
			List<ApiCreditCardResponseModel> response = new List<ApiCreditCardResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aa8b53cd1532605814b4e9af4b56a236</Hash>
</Codenesium>*/