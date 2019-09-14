using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.DataAccess
{
	public partial interface IProductRepository
	{
		Task<Product> Create(Product item);

		Task Update(Product item);

		Task Delete(int id);

		Task<Product> Get(int id);

		Task<List<Product>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>6d8c72ef79d20f7fc7b096f312c3c868</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/