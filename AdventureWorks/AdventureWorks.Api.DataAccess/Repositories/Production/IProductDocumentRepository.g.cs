using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDocumentRepository
	{
		Task<ProductDocument> Create(ProductDocument item);

		Task Update(ProductDocument item);

		Task Delete(int productID);

		Task<ProductDocument> Get(int productID);

		Task<List<ProductDocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5cb5b5eb1b3ced7906fd93b6a3205e31</Hash>
</Codenesium>*/