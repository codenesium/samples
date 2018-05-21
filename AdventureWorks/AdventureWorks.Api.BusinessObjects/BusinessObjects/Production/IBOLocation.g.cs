using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLocation
	{
		Task<CreateResponse<POCOLocation>> Create(
			ApiLocationModel model);

		Task<ActionResponse> Update(short locationID,
		                            ApiLocationModel model);

		Task<ActionResponse> Delete(short locationID);

		Task<POCOLocation> Get(short locationID);

		Task<List<POCOLocation>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOLocation> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>1c24cfcfe6f3c29e3dc3fc4f90d90b45</Hash>
</Codenesium>*/