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
    <Hash>525c9531e2c0128ee8886b21e0bcefb2</Hash>
</Codenesium>*/