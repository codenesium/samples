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
			BOCreditCard BOCreditCard = new BOCreditCard();

			BOCreditCard.SetProperties(
				creditCardID,
				model.CardNumber,
				model.CardType,
				model.ExpMonth,
				model.ExpYear,
				model.ModifiedDate);
			return BOCreditCard;
		}

		public virtual ApiCreditCardResponseModel MapBOToModel(
			BOCreditCard BOCreditCard)
		{
			if (BOCreditCard == null)
			{
				return null;
			}

			var model = new ApiCreditCardResponseModel();

			model.SetProperties(BOCreditCard.CardNumber, BOCreditCard.CardType, BOCreditCard.CreditCardID, BOCreditCard.ExpMonth, BOCreditCard.ExpYear, BOCreditCard.ModifiedDate);

			return model;
		}

		public virtual List<ApiCreditCardResponseModel> MapBOToModel(
			List<BOCreditCard> BOs)
		{
			List<ApiCreditCardResponseModel> response = new List<ApiCreditCardResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c35ed4b198d479c95a336547f8a9ffff</Hash>
</Codenesium>*/