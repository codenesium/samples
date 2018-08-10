using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IPersonCreditCardRepository
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
    <Hash>588610d42371ce1528649e4003aaa9ff</Hash>
</Codenesium>*/