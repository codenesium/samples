using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCostHistoryRepository
	{
		Task<DTOProductCostHistory> Create(DTOProductCostHistory dto);

		Task Update(int productID,
		            DTOProductCostHistory dto);

		Task Delete(int productID);

		Task<DTOProductCostHistory> Get(int productID);

		Task<List<DTOProductCostHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>77caeaefd38f80158c8213ea495b7325</Hash>
</Codenesium>*/