using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>4fbee63c89f8526f1b12f6eb0aaa6fce</Hash>
</Codenesium>*/