using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALPersonCreditCardMapper
	{
		public virtual PersonCreditCard MapBOToEF(
			BOPersonCreditCard bo)
		{
			PersonCreditCard efPersonCreditCard = new PersonCreditCard ();

			efPersonCreditCard.SetProperties(
				bo.BusinessEntityID,
				bo.CreditCardID,
				bo.ModifiedDate);
			return efPersonCreditCard;
		}

		public virtual BOPersonCreditCard MapEFToBO(
			PersonCreditCard ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOPersonCreditCard();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.CreditCardID,
				ef.ModifiedDate);
			return bo;
		}

		public virtual List<BOPersonCreditCard> MapEFToBO(
			List<PersonCreditCard> records)
		{
			List<BOPersonCreditCard> response = new List<BOPersonCreditCard>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3e2cb481469438dbf1d546265da0ef2f</Hash>
</Codenesium>*/