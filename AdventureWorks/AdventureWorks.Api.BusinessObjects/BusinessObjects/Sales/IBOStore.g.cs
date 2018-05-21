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

		Task<POCOStore> Get(int businessEntityID);

		Task<List<POCOStore>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOStore>> GetSalesPersonID(Nullable<int> salesPersonID);
		Task<List<POCOStore>> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>9ca65c6d505c522ea0f37af9ca4bd91b</Hash>
</Codenesium>*/