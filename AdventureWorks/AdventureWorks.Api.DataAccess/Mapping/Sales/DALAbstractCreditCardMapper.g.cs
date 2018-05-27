using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALCreditCardMapper
	{
		public virtual void MapDTOToEF(
			int creditCardID,
			DTOCreditCard dto,
			CreditCard efCreditCard)
		{
			efCreditCard.SetProperties(
				creditCardID,
				dto.CardNumber,
				dto.CardType,
				dto.ExpMonth,
				dto.ExpYear,
				dto.ModifiedDate);
		}

		public virtual DTOCreditCard MapEFToDTO(
			CreditCard ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOCreditCard();

			dto.SetProperties(
				ef.CreditCardID,
				ef.CardNumber,
				ef.CardType,
				ef.ExpMonth,
				ef.ExpYear,
				ef.ModifiedDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>b47fdbc9ff0b28513295efbd96be116b</Hash>
</Codenesium>*/