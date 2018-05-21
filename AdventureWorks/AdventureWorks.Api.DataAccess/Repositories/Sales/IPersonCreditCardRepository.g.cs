using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonCreditCardRepository
	{
		Task<POCOPersonCreditCard> Create(ApiPersonCreditCardModel model);

		Task Update(int businessEntityID,
		            ApiPersonCreditCardModel model);

		Task Delete(int businessEntityID);

		Task<POCOPersonCreditCard> Get(int businessEntityID);

		Task<List<POCOPersonCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b85eec7faad8bc8fa3fb34a8fa05e8b4</Hash>
</Codenesium>*/