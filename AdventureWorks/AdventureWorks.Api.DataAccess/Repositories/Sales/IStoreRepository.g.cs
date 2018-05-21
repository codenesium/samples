using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStoreRepository
	{
		Task<POCOStore> Create(ApiStoreModel model);

		Task Update(int businessEntityID,
		            ApiStoreModel model);

		Task Delete(int businessEntityID);

		Task<POCOStore> Get(int businessEntityID);

		Task<List<POCOStore>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOStore>> GetSalesPersonID(Nullable<int> salesPersonID);
		Task<List<POCOStore>> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>3a982fb9e59a4efcb5e7f72396aee9b6</Hash>
</Codenesium>*/