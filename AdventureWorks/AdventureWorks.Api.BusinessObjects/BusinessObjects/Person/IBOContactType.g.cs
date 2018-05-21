using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOContactType
	{
		Task<CreateResponse<POCOContactType>> Create(
			ApiContactTypeModel model);

		Task<ActionResponse> Update(int contactTypeID,
		                            ApiContactTypeModel model);

		Task<ActionResponse> Delete(int contactTypeID);

		Task<POCOContactType> Get(int contactTypeID);

		Task<List<POCOContactType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOContactType> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>e358c85f8e88ffcd7ce5786b52ad7f5b</Hash>
</Codenesium>*/