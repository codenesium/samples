using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOStore
	{
		Task<CreateResponse<int>> Create(
			StoreModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            StoreModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOStore Get(int businessEntityID);

		List<POCOStore> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d583b4d549c6316d05660ed01cf5a6bf</Hash>
</Codenesium>*/