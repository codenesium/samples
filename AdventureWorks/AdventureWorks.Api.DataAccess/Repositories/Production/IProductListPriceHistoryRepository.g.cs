using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductListPriceHistoryRepository
	{
		Task<DTOProductListPriceHistory> Create(DTOProductListPriceHistory dto);

		Task Update(int productID,
		            DTOProductListPriceHistory dto);

		Task Delete(int productID);

		Task<DTOProductListPriceHistory> Get(int productID);

		Task<List<DTOProductListPriceHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4811a973134d9592cb5eb733b7dd2dc3</Hash>
</Codenesium>*/