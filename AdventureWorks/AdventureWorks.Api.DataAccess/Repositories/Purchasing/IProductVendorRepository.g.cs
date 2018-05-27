using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductVendorRepository
	{
		Task<DTOProductVendor> Create(DTOProductVendor dto);

		Task Update(int productID,
		            DTOProductVendor dto);

		Task Delete(int productID);

		Task<DTOProductVendor> Get(int productID);

		Task<List<DTOProductVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOProductVendor>> GetBusinessEntityID(int businessEntityID);
		Task<List<DTOProductVendor>> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>4a3bac4bc70139405b64fade9643aad9</Hash>
</Codenesium>*/