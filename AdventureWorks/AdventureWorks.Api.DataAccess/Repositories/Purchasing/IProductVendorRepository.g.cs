using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductVendorRepository
	{
		POCOProductVendor Create(ApiProductVendorModel model);

		void Update(int productID,
		            ApiProductVendorModel model);

		void Delete(int productID);

		POCOProductVendor Get(int productID);

		List<POCOProductVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductVendor> GetBusinessEntityID(int businessEntityID);
		List<POCOProductVendor> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>481362c6673bda2c9a7e627c99e740de</Hash>
</Codenesium>*/