using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityRepository
	{
		POCOBusinessEntity Create(ApiBusinessEntityModel model);

		void Update(int businessEntityID,
		            ApiBusinessEntityModel model);

		void Delete(int businessEntityID);

		POCOBusinessEntity Get(int businessEntityID);

		List<POCOBusinessEntity> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e25eb836dae57e3ad4c9e0a47aa3a62a</Hash>
</Codenesium>*/