using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonCreditCardRepository
	{
		Task<PersonCreditCard> Create(PersonCreditCard item);

		Task Update(PersonCreditCard item);

		Task Delete(int businessEntityID);

		Task<PersonCreditCard> Get(int businessEntityID);

		Task<List<PersonCreditCard>> All(int limit = int.MaxValue, int offset = 0);

		Task<CreditCard> GetCreditCard(int creditCardID);
	}
}

/*<Codenesium>
    <Hash>b3afb5c623fb1f6be40a47dac9b761fe</Hash>
</Codenesium>*/