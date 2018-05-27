using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALPersonCreditCardMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOPersonCreditCard dto,
			PersonCreditCard efPersonCreditCard)
		{
			efPersonCreditCard.SetProperties(
				businessEntityID,
				dto.CreditCardID,
				dto.ModifiedDate);
		}

		public virtual DTOPersonCreditCard MapEFToDTO(
			PersonCreditCard ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPersonCreditCard();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.CreditCardID,
				ef.ModifiedDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>b98e0c3729da175dc30f02c7dff169fb</Hash>
</Codenesium>*/