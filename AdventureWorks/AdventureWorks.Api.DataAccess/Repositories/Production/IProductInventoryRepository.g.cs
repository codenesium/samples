using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductInventoryRepository
	{
		Task<DTOProductInventory> Create(DTOProductInventory dto);

		Task Update(int productID,
		            DTOProductInventory dto);

		Task Delete(int productID);

		Task<DTOProductInventory> Get(int productID);

		Task<List<DTOProductInventory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>67a2ebe2dc4d942943412547e2816a61</Hash>
</Codenesium>*/