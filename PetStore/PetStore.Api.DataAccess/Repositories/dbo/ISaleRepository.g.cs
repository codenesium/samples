using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface ISaleRepository
	{
		Task<POCOSale> Create(ApiSaleModel model);

		Task Update(int id,
		            ApiSaleModel model);

		Task Delete(int id);

		Task<POCOSale> Get(int id);

		Task<List<POCOSale>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ecd916d33fdd3e36c30e3b07a4327786</Hash>
</Codenesium>*/