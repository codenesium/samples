using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductVendorRepository
	{
		Task<POCOProductVendor> Create(ApiProductVendorModel model);

		Task Update(int productID,
		            ApiProductVendorModel model);

		Task Delete(int productID);

		Task<POCOProductVendor> Get(int productID);

		Task<List<POCOProductVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOProductVendor>> GetBusinessEntityID(int businessEntityID);
		Task<List<POCOProductVendor>> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>9ab2b57ede7d4043024723facb0d8bba</Hash>
</Codenesium>*/