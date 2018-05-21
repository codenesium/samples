using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductVendor
	{
		Task<CreateResponse<POCOProductVendor>> Create(
			ApiProductVendorModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductVendorModel model);

		Task<ActionResponse> Delete(int productID);

		Task<POCOProductVendor> Get(int productID);

		Task<List<POCOProductVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOProductVendor>> GetBusinessEntityID(int businessEntityID);
		Task<List<POCOProductVendor>> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>feef82f0b8896259eea53e9771ad3390</Hash>
</Codenesium>*/