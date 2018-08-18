using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractPersonCreditCardMapper
	{
		public virtual BOPersonCreditCard MapModelToBO(
			int businessEntityID,
			ApiPersonCreditCardRequestModel model
			)
		{
			BOPersonCreditCard boPersonCreditCard = new BOPersonCreditCard();
			boPersonCreditCard.SetProperties(
				businessEntityID,
				model.CreditCardID,
				model.ModifiedDate);
			return boPersonCreditCard;
		}

		public virtual ApiPersonCreditCardResponseModel MapBOToModel(
			BOPersonCreditCard boPersonCreditCard)
		{
			var model = new ApiPersonCreditCardResponseModel();

			model.SetProperties(boPersonCreditCard.BusinessEntityID, boPersonCreditCard.CreditCardID, boPersonCreditCard.ModifiedDate);

			return model;
		}

		public virtual List<ApiPersonCreditCardResponseModel> MapBOToModel(
			List<BOPersonCreditCard> items)
		{
			List<ApiPersonCreditCardResponseModel> response = new List<ApiPersonCreditCardResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2757ef69f80661f767d56b241f760ecc</Hash>
</Codenesium>*/