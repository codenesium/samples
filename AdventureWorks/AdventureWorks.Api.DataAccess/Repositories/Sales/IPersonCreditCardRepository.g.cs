using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonCreditCardRepository
	{
		Task<DTOPersonCreditCard> Create(DTOPersonCreditCard dto);

		Task Update(int businessEntityID,
		            DTOPersonCreditCard dto);

		Task Delete(int businessEntityID);

		Task<DTOPersonCreditCard> Get(int businessEntityID);

		Task<List<DTOPersonCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>200571533734421f51d8fcdb9ea5c122</Hash>
</Codenesium>*/