using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPersonCreditCardMapper
	{
		public virtual BOPersonCreditCard MapModelToBO(
			int businessEntityID,
			ApiPersonCreditCardRequestModel model
			)
		{
			BOPersonCreditCard BOPersonCreditCard = new BOPersonCreditCard();

			BOPersonCreditCard.SetProperties(
				businessEntityID,
				model.CreditCardID,
				model.ModifiedDate);
			return BOPersonCreditCard;
		}

		public virtual ApiPersonCreditCardResponseModel MapBOToModel(
			BOPersonCreditCard BOPersonCreditCard)
		{
			if (BOPersonCreditCard == null)
			{
				return null;
			}

			var model = new ApiPersonCreditCardResponseModel();

			model.SetProperties(BOPersonCreditCard.BusinessEntityID, BOPersonCreditCard.CreditCardID, BOPersonCreditCard.ModifiedDate);

			return model;
		}

		public virtual List<ApiPersonCreditCardResponseModel> MapBOToModel(
			List<BOPersonCreditCard> BOs)
		{
			List<ApiPersonCreditCardResponseModel> response = new List<ApiPersonCreditCardResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c46572856d165cba5caaf94819e6688e</Hash>
</Codenesium>*/