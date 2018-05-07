using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IStoreRepository
	{
		int Create(StoreModel model);

		void Update(int businessEntityID,
		            StoreModel model);

		void Delete(int businessEntityID);

		POCOStore Get(int businessEntityID);

		List<POCOStore> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7b724f25af36d09911dd633ba289e444</Hash>
</Codenesium>*/