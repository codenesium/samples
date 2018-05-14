using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductRepository
	{
		POCOProduct Create(ApiProductModel model);

		void Update(int productID,
		            ApiProductModel model);

		void Delete(int productID);

		POCOProduct Get(int productID);

		List<POCOProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOProduct GetName(string name);

		POCOProduct GetProductNumber(string productNumber);
	}
}

/*<Codenesium>
    <Hash>1daa600625447fc70fb74a4196b65aa9</Hash>
</Codenesium>*/