using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ILocationRepository
	{
		Task<POCOLocation> Create(ApiLocationModel model);

		Task Update(short locationID,
		            ApiLocationModel model);

		Task Delete(short locationID);

		Task<POCOLocation> Get(short locationID);

		Task<List<POCOLocation>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOLocation> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>aa8a032ff24c25f66414ccc45eb73461</Hash>
</Codenesium>*/