using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCulture
	{
		Task<CreateResponse<POCOCulture>> Create(
			ApiCultureModel model);

		Task<ActionResponse> Update(string cultureID,
		                            ApiCultureModel model);

		Task<ActionResponse> Delete(string cultureID);

		Task<POCOCulture> Get(string cultureID);

		Task<List<POCOCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCulture> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>b3d799093354aaff065c5411e12fd157</Hash>
</Codenesium>*/