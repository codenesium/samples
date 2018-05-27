using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLCreditCardMapper
	{
		public virtual DTOCreditCard MapModelToDTO(
			int creditCardID,
			ApiCreditCardRequestModel model
			)
		{
			DTOCreditCard dtoCreditCard = new DTOCreditCard();

			dtoCreditCard.SetProperties(
				creditCardID,
				model.CardNumber,
				model.CardType,
				model.ExpMonth,
				model.ExpYear,
				model.ModifiedDate);
			return dtoCreditCard;
		}

		public virtual ApiCreditCardResponseModel MapDTOToModel(
			DTOCreditCard dtoCreditCard)
		{
			if (dtoCreditCard == null)
			{
				return null;
			}

			var model = new ApiCreditCardResponseModel();

			model.SetProperties(dtoCreditCard.CardNumber, dtoCreditCard.CardType, dtoCreditCard.CreditCardID, dtoCreditCard.ExpMonth, dtoCreditCard.ExpYear, dtoCreditCard.ModifiedDate);

			return model;
		}

		public virtual List<ApiCreditCardResponseModel> MapDTOToModel(
			List<DTOCreditCard> dtos)
		{
			List<ApiCreditCardResponseModel> response = new List<ApiCreditCardResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>54617529afa54439b2fc3017e0912606</Hash>
</Codenesium>*/