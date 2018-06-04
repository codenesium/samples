using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonCreditCardRepository
	{
		Task<PersonCreditCard> Create(PersonCreditCard item);

		Task Update(PersonCreditCard item);

		Task Delete(int businessEntityID);

		Task<PersonCreditCard> Get(int businessEntityID);

		Task<List<PersonCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5f8fffddcea1f2c6a17495da2cea81ae</Hash>
</Codenesium>*/