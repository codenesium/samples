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
		Task<CreateResponse<POCOStore>> Create(
			ApiStoreModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiStoreModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOStore Get(int businessEntityID);

		List<POCOStore> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStore> GetSalesPersonID(Nullable<int> salesPersonID);
		List<POCOStore> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>8ebabc62b6ecba2bd4c89c5d0fb489bb</Hash>
</Codenesium>*/