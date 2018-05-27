using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICreditCardRepository
	{
		Task<DTOCreditCard> Create(DTOCreditCard dto);

		Task Update(int creditCardID,
		            DTOCreditCard dto);

		Task Delete(int creditCardID);

		Task<DTOCreditCard> Get(int creditCardID);

		Task<List<DTOCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOCreditCard> GetCardNumber(string cardNumber);
	}
}

/*<Codenesium>
    <Hash>cf218519985ec156305ac9eefda3518a</Hash>
</Codenesium>*/