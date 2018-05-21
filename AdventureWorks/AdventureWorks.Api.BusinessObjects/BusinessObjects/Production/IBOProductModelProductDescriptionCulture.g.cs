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

		Task<POCOProductModelProductDescriptionCulture> Get(int productModelID);

		Task<List<POCOProductModelProductDescriptionCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>901eebc60a96b6728f381305a03a5ffa</Hash>
</Codenesium>*/