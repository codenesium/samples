using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICultureRepository
	{
		Task<POCOCulture> Create(ApiCultureModel model);

		Task Update(string cultureID,
		            ApiCultureModel model);

		Task Delete(string cultureID);

		Task<POCOCulture> Get(string cultureID);

		Task<List<POCOCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCulture> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>f2a42443e89f8c9229326a120011a39b</Hash>
</Codenesium>*/