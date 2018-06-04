using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductRepository
	{
		Task<Product> Create(Product item);

		Task Update(Product item);

		Task Delete(int productID);

		Task<Product> Get(int productID);

		Task<List<Product>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<Product> GetName(string name);
		Task<Product> GetProductNumber(string productNumber);
	}
}

/*<Codenesium>
    <Hash>b86ef755a540c2b56f9b782388938c05</Hash>
</Codenesium>*/