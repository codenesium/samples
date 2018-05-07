using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductVendorRepository
	{
		int Create(ProductVendorModel model);

		void Update(int productID,
		            ProductVendorModel model);

		void Delete(int productID);

		POCOProductVendor Get(int productID);

		List<POCOProductVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0e74378f0b942ff7aa5f1598b6a9229f</Hash>
</Codenesium>*/