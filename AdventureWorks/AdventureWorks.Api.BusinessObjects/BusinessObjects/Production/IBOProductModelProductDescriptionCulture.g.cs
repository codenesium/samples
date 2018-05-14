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
		Task<CreateResponse<POCOProductModelProductDescriptionCulture>> Create(
			ApiProductModelProductDescriptionCultureModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ApiProductModelProductDescriptionCultureModel model);

		Task<ActionResponse> Delete(int productModelID);

		POCOProductModelProductDescriptionCulture Get(int productModelID);

		List<POCOProductModelProductDescriptionCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>43b516acdb722dcc9a34caa4f6d527d8</Hash>
</Codenesium>*/