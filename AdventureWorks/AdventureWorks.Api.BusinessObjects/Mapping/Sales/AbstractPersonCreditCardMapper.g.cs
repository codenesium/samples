using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPersonCreditCardMapper
	{
		public virtual DTOPersonCreditCard MapModelToDTO(
			int businessEntityID,
			ApiPersonCreditCardRequestModel model
			)
		{
			DTOPersonCreditCard dtoPersonCreditCard = new DTOPersonCreditCard();

			dtoPersonCreditCard.SetProperties(
				businessEntityID,
				model.CreditCardID,
				model.ModifiedDate);
			return dtoPersonCreditCard;
		}

		public virtual ApiPersonCreditCardResponseModel MapDTOToModel(
			DTOPersonCreditCard dtoPersonCreditCard)
		{
			if (dtoPersonCreditCard == null)
			{
				return null;
			}

			var model = new ApiPersonCreditCardResponseModel();

			model.SetProperties(dtoPersonCreditCard.BusinessEntityID, dtoPersonCreditCard.CreditCardID, dtoPersonCreditCard.ModifiedDate);

			return model;
		}

		public virtual List<ApiPersonCreditCardResponseModel> MapDTOToModel(
			List<DTOPersonCreditCard> dtos)
		{
			List<ApiPersonCreditCardResponseModel> response = new List<ApiPersonCreditCardResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3d0d0cc1e0dd1c4c5f99ce32b49de92f</Hash>
</Codenesium>*/