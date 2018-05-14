using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStoreRepository
	{
		POCOStore Create(ApiStoreModel model);

		void Update(int businessEntityID,
		            ApiStoreModel model);

		void Delete(int businessEntityID);

		POCOStore Get(int businessEntityID);

		List<POCOStore> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStore> GetSalesPersonID(Nullable<int> salesPersonID);
		List<POCOStore> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>71d6aa1a51e57c3afdf6ab37ae585565</Hash>
</Codenesium>*/