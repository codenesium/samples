using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

			model.SetProperties(boCreditCard.CardNumber, boCreditCard.CardType, boCreditCard.CreditCardID, boCreditCard.ExpMonth, boCreditCard.ExpYear, boCreditCard.ModifiedDate);

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
    <Hash>4b6d13b184a07581a3514ec5262af9dc</Hash>
</Codenesium>*/