using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductModelProductDescriptionCulture
	{
		Task<CreateResponse<int>> Create(
			ProductModelProductDescriptionCultureModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ProductModelProductDescriptionCultureModel model);

		Task<ActionResponse> Delete(int productModelID);

		POCOProductModelProductDescriptionCulture Get(int productModelID);

		List<POCOProductModelProductDescriptionCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>240d75c85eea42af2295205263f4718c</Hash>
</Codenesium>*/