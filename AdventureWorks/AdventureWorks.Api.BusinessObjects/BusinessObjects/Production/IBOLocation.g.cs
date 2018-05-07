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
		Task<CreateResponse<short>> Create(
			LocationModel model);

		Task<ActionResponse> Update(short locationID,
		                            LocationModel model);

		Task<ActionResponse> Delete(short locationID);

		POCOLocation Get(short locationID);

		List<POCOLocation> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>912eac1f317c9ccef08e8b685f380c94</Hash>
</Codenesium>*/