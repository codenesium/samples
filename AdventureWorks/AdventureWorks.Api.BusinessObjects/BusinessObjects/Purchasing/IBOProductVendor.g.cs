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

		POCOProductVendor Get(int productID);

		List<POCOProductVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductVendor> GetBusinessEntityID(int businessEntityID);
		List<POCOProductVendor> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>0a10f1760817cd1c6125970f49b3c09d</Hash>
</Codenesium>*/